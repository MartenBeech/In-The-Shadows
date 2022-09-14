using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    static GameObject player;
    static Vector3Int pos;
    public Vector3Int Pos {
        get { return pos; }
        set { pos = value; }
    }
    static int scent = 5;
    public int Scent {
        get { return scent; }
        set { scent = value; }
    }
    public void CreatePlayer(Vector3Int _pos) {
        GameObject prefab = Resources.Load<GameObject>("Assets/Player");
        GameObject parent = GameObject.Find("Players");
        player = Instantiate(prefab, new Vector3(_pos.x * Tile.TILE_SIZE, _pos.y * Tile.TILE_SIZE, -1), parent.transform.rotation, parent.transform);
        player.name = "Player";
        pos = _pos;

        Obstacle obstacle = new();
        obstacle.CreatePlayer(pos);

        Scout scout = new();
        scout.CreateLightAroundPos(pos);

        Cam cam = new();
        cam.SetPosition(new Vector3(_pos.x * Tile.TILE_SIZE, _pos.y * Tile.TILE_SIZE));
    }

    
}
