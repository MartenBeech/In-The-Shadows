using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    static GameObject player;
    public static Vector3Int pos;
    public void CreatePlayer(Vector3Int _pos) {
        GameObject prefab = Resources.Load<GameObject>("Assets/Player");
        GameObject parent = GameObject.Find("Players");
        player = Instantiate(prefab, new Vector3(_pos.x * Tile.TILE_SIZE, _pos.y * Tile.TILE_SIZE, -1), parent.transform.rotation, parent.transform);
        player.name = "Player";
        pos = _pos;

        Obstacle obstacle = new Obstacle();
        obstacle.CreatePlayer(pos);

        Scout scout = new Scout();
        scout.CreateLightAroundPos(pos);

        Cam cam = new Cam();
        cam.SetPosition(new Vector3(_pos.x * Tile.TILE_SIZE, _pos.y * Tile.TILE_SIZE));
    }
}
