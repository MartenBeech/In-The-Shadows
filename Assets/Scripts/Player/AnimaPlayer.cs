using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaPlayer : MonoBehaviour
{
    public Vector3Int fromPoint;
    public Vector3Int toPoint;
    public float counter = -1;
    int speed = 4;

    private void Update() {
        if (counter >= 0) {
            Vector3 dir = toPoint - fromPoint;
            float dist = Mathf.Sqrt(
                Mathf.Pow(toPoint.x - fromPoint.x, 2) +
                Mathf.Pow(toPoint.y - fromPoint.y, 2));
            transform.Translate(dir.normalized * dist * Time.deltaTime * speed);
            counter -= Time.deltaTime * speed;

            if (counter < 0) {
                transform.position = new Vector3(toPoint.x, toPoint.y, -1);
                PlayerMovement.movementInAction = false;
                
            }
        }
    }

    public void MovePlayer(GameObject gameObject, Vector3Int from, Vector3Int to) {
        gameObject.GetComponentInChildren<AnimaPlayer>().fromPoint = new Vector3Int(from.x * Tile.TILE_SIZE, from.y * Tile.TILE_SIZE);
        gameObject.GetComponentInChildren<AnimaPlayer>().toPoint = new Vector3Int(to.x * Tile.TILE_SIZE, to.y * Tile.TILE_SIZE);
        gameObject.GetComponentInChildren<AnimaPlayer>().counter = 1;
        PlayerMovement.movementInAction = true;
    }
}
