using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scout : MonoBehaviour
{
    static bool[,] revealed;
    static bool[,] vision;
    static int range = 5;

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
        for (int x = pos.x - range; x <= pos.x + range; x++) {
            for (int y = pos.y - range; y <= pos.y + range; y++) {
                CreateShadow(new Vector3Int(x, y));
            }
        }
    }

    public void CreateShadow(Vector3Int pos) {
        vision[pos.x, pos.y] = false;
        Map map = new Map();
        map.PlaceMapTile(pos);
    }

    public void CreateLightAroundPos(Vector3Int pos) {
        for (int x = pos.x - range; x <= pos.x + range; x++) {
            for (int y = pos.y - range; y <= pos.y + range; y++) {
                CreateLight(new Vector3Int(x, y));
            }
        }
    }

    public void CreateLight(Vector3Int pos) {
        Dungeon dungeon = new Dungeon();
        if (dungeon.GetInsideDungeon(pos)) {
            revealed[pos.x, pos.y] = true;
            vision[pos.x, pos.y] = true;
            Map map = new Map();
            map.PlaceMapTile(pos);
        }
    }

    public bool GetRevealed(Vector3Int pos) {
        return revealed[pos.x, pos.y];
    }

    public bool GetVision(Vector3Int pos) {
        return vision[pos.x, pos.y];
    }
}
