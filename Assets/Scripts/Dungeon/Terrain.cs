using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terrain : MonoBehaviour
{
    enum Type
    {
        Wall, Path, Start, End
    };

    public void CreateTerrain(int size)
    {
        Type[,] types = new Type[size, size];
        CreateWalls(size, types);
        Vector3Int[] centerPoints = CreateRooms(size, types);
        CreateRoomPaths(size, types, centerPoints);
        CreateStairs(size, types);
        PlaceTerrain(size, types);
    }

    private void CreateWalls(int size, Type[,] types)
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                types[x, y] = Type.Wall;
            }
        }
    }

    private Vector3Int[] CreateRooms(int size, Type[,] types)
    {
        Rng rng = new Rng();
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

    private void CreateRoomPaths(int size, Type[,] types, Vector3Int[] centerPoints) 
    {
        for (int i = 0; i < centerPoints.Length - 1; i++) {
            CreateRoomPath(size, types, centerPoints[i], centerPoints[i + 1]);
        }
    }

    private void CreateRoomPath(int size, Type[,] types, Vector3Int from, Vector3Int to) 
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

        Rng rng = new Rng();
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

    private void CreateStairs(int size, Type[,] types) {
        List<Vector3Int> paths = new List<Vector3Int>();

        for (int x = 0; x < size; x++) {
            for (int y = 0; y < size; y++) {
                if (types[x, y] == Type.Path) {
                    paths.Add(new Vector3Int(x, y));
                }
            }
        }

        Rng rng = new Rng();
        int rndPath = rng.Range(0, paths.Count);
        Vector3Int startPos = paths[rndPath];
        paths.RemoveAt(rndPath);
        rndPath = rng.Range(0, paths.Count);
        Vector3Int endPos = paths[rndPath];

        types[startPos.x, startPos.y] = Type.Start;
        types[endPos.x, endPos.y] = Type.End;
    }

    private void PlaceTerrain(int size, Type[,] types)
    {
        Tile tile = new Tile();
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                GameObject.Find(tile.GetName(x, y)).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/{types[x, y]}");
            }
        }
    }
}
