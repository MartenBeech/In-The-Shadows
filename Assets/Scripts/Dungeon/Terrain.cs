using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terrain : MonoBehaviour
{
    public enum Type
    {
        Wall, Path, Start, End
    };
    static Type[,] types;

    public void CreateTerrain(int size)
    {
        types = new Type[size, size];
        CreateWalls(size);
        Vector3Int[] centerPoints = CreateRooms(size);
        CreateRoomPaths(size, centerPoints);
        CreateStairs(size);
    }

    private void CreateWalls(int size)
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                types[x, y] = Type.Wall;
            }
        }
    }

    private Vector3Int[] CreateRooms(int size)
    {
        Rng rng = new();
        int nRooms = size / 2;

        Vector3Int[] centerPoints = new Vector3Int[nRooms];
        for (int i = 0; i < nRooms; i++)
        {
            Vector3Int centerPoint = new Vector3Int(rng.Range(0, size), rng.Range(0, size));
            centerPoints[i] = centerPoint;
            Vector3Int pathAhead = new Vector3Int(rng.Range(1, 5), rng.Range(1, 5));
            Vector3Int pathBehind = new Vector3Int(rng.Range(1, 5), rng.Range(1, 5));
            for (int x = centerPoint.x - pathBehind.x; x < centerPoint.x + pathAhead.x; x++)
            {
                for (int y = centerPoint.y - pathBehind.y; y < centerPoint.y + pathAhead.y; y++)
                {
                    if (x > 0 && y > 0 && x < size - 2 && y < size - 2) {
                        types[x, y] = Type.Path;
                    }
                }
            }
        }
        return centerPoints;
    }

    private void CreateRoomPaths(int size, Vector3Int[] centerPoints) 
    {
        for (int i = 0; i < centerPoints.Length - 1; i++) {
            CreateRoomPath(size, centerPoints[i], centerPoints[i + 1]);
        }
    }

    private void CreateRoomPath(int size, Vector3Int from, Vector3Int to) 
    {
        List<char> directions = new List<char>();
        for (int x = from.x; x < to.x; x++) {
            directions.Add('E');
        }
        for (int x = from.x; x > to.x; x--) {
            directions.Add('W');
        }
        for (int y = from.y; y < to.y; y++) {
            directions.Add('N');
        }
        for (int y = from.y; y > to.y; y--) {
            directions.Add('S');
        }

        Rng rng = new();
        while (directions.Count > 0) {
            int rnd = rng.Range(0, directions.Count);
            if (directions[rnd] == 'E') {
                from.x++;
            }
            if (directions[rnd] == 'W') {
                from.x--;
            }
            if (directions[rnd] == 'N') {
                from.y++;
            }
            if (directions[rnd] == 'S') {
                from.y--;
            }
            if (from.x > 0 && from.y > 0 && from.x < size - 1 && from.y < size - 1) {
                types[from.x, from.y] = Type.Path;
            }
            directions.RemoveAt(rnd);
        }
    }

    public List<Vector3Int> GetAllPathTiles(int size) {
        List<Vector3Int> paths = new List<Vector3Int>();
        Obstacle obstacle = new();

        for (int x = 0; x < size; x++) {
            for (int y = 0; y < size; y++) {
                if (types[x, y] == Type.Path && obstacle.GetObstacle(new Vector3Int(x, y)) == Obstacle.Type.Null) {
                    paths.Add(new Vector3Int(x, y));
                }
            }
        }
        return paths;
    }

    private void CreateStairs(int size) {
        List<Vector3Int> paths = GetAllPathTiles(size);

        Rng rng = new();
        int rndPath = rng.Range(0, paths.Count);
        Vector3Int startPos = paths[rndPath];
        paths.RemoveAt(rndPath);
        rndPath = rng.Range(0, paths.Count);
        Vector3Int endPos = paths[rndPath];

        types[startPos.x, startPos.y] = Type.Start;
        types[endPos.x, endPos.y] = Type.End;

        Player player = new();
        player.CreatePlayer(startPos);
    }

    public Type GetTerrain(Vector3Int pos) {
        return types[pos.x, pos.y];
    }

    public bool GetPassable(Vector3Int pos) {
        Type type = types[pos.x, pos.y];
        if (type == Type.Wall) {
            return false;
        }
        return true;
    }

    public void PlaceTerrainAroundPos(Vector3Int pos, int range) {
        Dungeon dungeon = new();
        Tile tile = new();
        Scout scout = new();
        Rng rng = new();

        for (int x = pos.x - range; x <= pos.x + range; x++) {
            for (int y = pos.y - range; y <= pos.y + range; y++) {
                if (dungeon.IsInsideDungeon(new Vector3Int(x, y))) {
                    PlaceTerrain(new Vector3Int(x, y), dungeon, tile, scout, types[x, y], rng);
                }
            }
        }
    }

    public void PlaceTerrain(Vector3Int pos, Dungeon dungeon, Tile tile, Scout scout, Type type, Rng rng) {
        if (dungeon.IsInsideDungeon(pos)) {
            GameObject gameObject = GameObject.Find(tile.GetName(pos.x, pos.y));
            switch(type) {
                case Type.Path:
                    PlacePath(gameObject, rng);
                    break;
                case Type.Wall:
                    PlaceWall(gameObject);
                    break;
                case Type.Start:
                    PlaceStart(gameObject);
                    break;
                case Type.End:
                    PlaceEnd(gameObject);
                    break;
            }
            
            if (scout.GetVision(pos)) {
                gameObject.GetComponent<Image>().color = Color.HSVToRGB(0 / 360f, 0, 1f); //White
            } else {
                gameObject.GetComponent<Image>().color = Color.HSVToRGB(0 / 360f, 0, 0.75f); //Light gray
            }
        }
    }

    private void PlacePath(GameObject gameObject, Rng rng) {
        int rnd = rng.Range(0, 16);
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/Paths/Path{rnd}");
    }

    private void PlaceWall(GameObject gameObject) {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/Walls/Wall");
    }

    private void PlaceStart(GameObject gameObject) {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/Stairs/Start");
    }

    private void PlaceEnd(GameObject gameObject) {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/Stairs/End");
    }
}
