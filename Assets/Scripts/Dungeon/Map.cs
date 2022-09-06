using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public void CreateMapTiles(int size) {
        int tileSize = 250 / size;
        GameObject prefab = Resources.Load<GameObject>("Assets/MapTile");
        GameObject parent = GameObject.Find("MapTiles");
        for (int x = 0; x < size; x++) {
            for (int y = 0; y < size; y++) {
                GameObject mapTile = Instantiate(prefab, new Vector3(x * tileSize, y * tileSize, -2) + parent.transform.position, parent.transform.rotation, parent.transform);
                mapTile.name = GetName(x, y);
                mapTile.transform.localScale = new Vector3(2.5f / size, 2.5f / size, 2.5f / size);
            }
        }
    }

    private string GetName(int x, int y) {
        return $"MapTile{x}-{y}";
    }

    public void PlaceMapTiles(int size) {
        for (int x = 0; x < size; x++) {
            for (int y = 0; y < size; y++) {
                PlaceMapTile(new Vector3Int(x, y));
            }
        }
    }

    public void PlaceMapTile(Vector3Int pos) {
        Terrain terrain = new Terrain();
        Obstacle obstacle = new Obstacle();

        Terrain.Type terrainType = terrain.GetTerrain(pos);
        Obstacle.Type obstacleType = obstacle.GetObstacle(pos);

        GameObject.Find(GetName(pos.x, pos.y)).GetComponent<Image>().color = GetMapColor(pos, terrainType, obstacleType);
    }

    private Color GetMapColor(Vector3Int pos, Terrain.Type terrainType, Obstacle.Type obstacleType) {
        Scout scout = new Scout();
        if (scout.GetRevealed(pos)) {
            if (scout.GetVision(pos)) { 
                if (obstacleType == Obstacle.Type.Player) {
                    return Color.HSVToRGB(120 / 360f, 1, 1); //Green
                }
                if (obstacleType == Obstacle.Type.Enemy) {
                    return Color.HSVToRGB(0 / 360f, 1, 1); //Red
                }
            }
            if (terrainType == Terrain.Type.Start) {
                return Color.HSVToRGB(210 / 360f, 0.5f, 1); //Light cyan
            }
            if (terrainType == Terrain.Type.End) {
                return Color.HSVToRGB(210 / 360f, 1, 1); //Cyan
            }
            if (terrainType == Terrain.Type.Wall) {
                return Color.HSVToRGB(0 / 360f, 1, 0); //Black
            }
            if (terrainType == Terrain.Type.Path) {
                return Color.HSVToRGB(0 / 360f, 0, 1); //White
            }
        }
        return Color.HSVToRGB(0 / 360f, 0, 0.5f); //Gray
    }
}
