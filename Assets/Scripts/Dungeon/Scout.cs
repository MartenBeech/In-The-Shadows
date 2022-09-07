using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scout : MonoBehaviour
{
    static bool[,] revealed;
    static bool[,] vision;
    static int range = 3;

    public void CreateScouting(int size) {
        revealed = new bool[size, size];
        vision = new bool[size, size];
    }

    public void CreateShadows(int size) {
        for (int x = 0; x < size; x++) {
            for (int y = 0; y < size; y++) {
                CreateShadow(new Vector3Int(x, y));
            }
        }
    }

    public void CreateShadowsAroundPos(Vector3Int pos) {
        Dungeon dungeon = new();
        for (int x = pos.x - range; x <= pos.x + range; x++) {
            for (int y = pos.y - range; y <= pos.y + range; y++) {
                if (dungeon.GetInsideDungeon(new Vector3Int(x, y))) {
                    CreateShadow(new Vector3Int(x, y));
                }
            }
        }
        Map map = new();
        map.PlaceMapTilesAroundPos(pos, range);
        Terrain terrain = new();
        terrain.PlaceTerrainAroundPos(pos, range);
    }

    public void CreateShadow(Vector3Int pos) {
        vision[pos.x, pos.y] = false;
    }

    public void CreateLightAroundPos(Vector3Int pos) {
        Dungeon dungeon = new();
        for (int x = pos.x - range; x <= pos.x + range; x++) {
            for (int y = pos.y - range; y <= pos.y + range; y++) {
                if (dungeon.GetInsideDungeon(new Vector3Int(x, y))) {
                    CreateLight(new Vector3Int(x, y));
                }
            }
        }
        Map map = new();
        map.PlaceMapTilesAroundPos(pos, range);
        Terrain terrain = new();
        terrain.PlaceTerrainAroundPos(pos, range);
    }

    public void CreateLight(Vector3Int pos) {
        revealed[pos.x, pos.y] = true;
        vision[pos.x, pos.y] = true;
    }

    public bool GetRevealed(Vector3Int pos) {
        return revealed[pos.x, pos.y];
    }

    public bool GetVision(Vector3Int pos) {
        return vision[pos.x, pos.y];
    }
}
