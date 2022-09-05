using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dungeon : MonoBehaviour
{
    public void CreateDungeon(int size)
    {
        Tile tile = new Tile();
        tile.CreateTiles(size);
        Obstacle obstacle = new Obstacle();
        obstacle.CreateObstacles(size);
        Terrain terrain = new Terrain();
        terrain.CreateTerrain(size);
        Enemy enemy = new Enemy();
        enemy.CreateEnemies(size);
        Map map = new Map();
        map.CreateMapTiles(size);
        map.PlaceMapTiles(size);
    }
}
