using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public static bool movementInAction = false;

    void Update()
    {
        if (!movementInAction) {
            if (Input.GetKey(KeyCode.W)) {
                MovePlayer(Player.pos, new Vector3Int(Player.pos.x, Player.pos.y + 1));
            } else if (Input.GetKey(KeyCode.S)) {
                MovePlayer(Player.pos, new Vector3Int(Player.pos.x, Player.pos.y - 1));
            } else if (Input.GetKey(KeyCode.D)) {
                MovePlayer(Player.pos, new Vector3Int(Player.pos.x + 1, Player.pos.y));
            } else if (Input.GetKey(KeyCode.A)) {
                MovePlayer(Player.pos, new Vector3Int(Player.pos.x - 1, Player.pos.y));
            }
        }
    }

    public void MovePlayer(Vector3Int from, Vector3Int to) {
        Obstacle obstacle = new Obstacle();
        if (obstacle.GetObstacle(to) == Obstacle.Type.Enemy) {
            return;
        }
        Terrain terrain = new Terrain();
        if (terrain.GetTerrain(to) == Terrain.Type.Wall) {
            return;
        }

        Scout scout = new Scout();
        scout.CreateShadowsAroundPos(from);
        scout.CreateLightAroundPos(to);

        obstacle.MoveObstacle(from, to);
        AnimaPlayer animaPlayer = new AnimaPlayer();
        animaPlayer.MovePlayer(player, from, to);
        Player.pos = to;
    }
}
