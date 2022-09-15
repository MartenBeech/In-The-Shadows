using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dungeon : MonoBehaviour
{
    static int size;
    public void CreateDungeon(int _size)
    {
        size = _size;
        Tile tile = new();
        tile.CreateTiles(size);
        Map map = new();
        map.CreateMapTiles(size);
        Scout scout = new();
        scout.CreateScouting(size);
        Obstacle obstacle = new();
        obstacle.CreateObstacles(size);
        Terrain terrain = new();
        terrain.CreateTerrain(size);
        Enemy enemy = new();
        enemy.CreateEnemies(size);
        scout.CreateShadows(size);
    }

    public bool IsInsideDungeon(Vector3Int pos) {
        if (pos.x < 0) {
            return false;
        }
        if (pos.y < 0) {
            return false;
        }
        if (pos.x >= size) {
            return false;
        }
        if (pos.y >= size) {
            return false;
        }
        return true;
    }
}
