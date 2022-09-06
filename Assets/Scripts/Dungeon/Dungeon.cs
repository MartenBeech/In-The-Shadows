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
        Tile tile = new Tile();
        tile.CreateTiles(size);
        Map map = new Map();
        map.CreateMapTiles(size);
        Scout scout = new Scout();
        scout.CreateScouting(size);
        Obstacle obstacle = new Obstacle();
        obstacle.CreateObstacles(size);
        Terrain terrain = new Terrain();
        terrain.CreateTerrain(size);
        Enemy enemy = new Enemy();
        enemy.CreateEnemies(size);
        scout.CreateShadows(size);
    }

    public bool GetInsideDungeon(Vector3Int pos) {
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
