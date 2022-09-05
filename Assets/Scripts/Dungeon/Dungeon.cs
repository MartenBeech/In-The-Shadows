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
        Terrain terrain = new Terrain();
        terrain.CreateTerrain(size);
    }
}
