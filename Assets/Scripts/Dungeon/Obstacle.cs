using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public enum Type {
        Null, Player, Enemy
    };
    static Type[,] types;

    public void CreateObstacles(int size) {
        types = new Type[size, size];
        RemoveObstacles(size);
    }

    private void RemoveObstacles(int size) {
        for (int x = 0; x < size; x++) {
            for (int y = 0; y < size; y++) {
                types[x, y] = Type.Null;
            }
        }
    }

    public void CreatePlayer(Vector3Int pos) {
        types[pos.x, pos.y] = Type.Player;
    }

    public void CreateEnemy(Vector3Int pos) {
        types[pos.x, pos.y] = Type.Enemy;
    }

    public void MoveObstacle(Vector3Int from, Vector3Int to) {
        types[to.x, to.y] = types[from.x, from.y];
        types[from.x, from.y] = Type.Null;
        Map map = new();
        map.PlaceMapTilesAroundPos(from, 0);
        map.PlaceMapTilesAroundPos(to, 0);
    }

    public Type GetObstacle(Vector3Int pos) {
        return types[pos.x, pos.y];
    }

    public bool GetPassable(Vector3Int pos) {
        Type type = types[pos.x, pos.y];
        if (type == Type.Enemy) {
            return false;
        }
        if (type == Type.Player) {
            return false;
        }
        return true;
    }
}
