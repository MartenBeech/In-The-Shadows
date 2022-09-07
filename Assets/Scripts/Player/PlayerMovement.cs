using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerGameObject;
    static bool movementInAction = false;

    void Update()
    {
        if (!movementInAction) {
            if (Input.GetKey(KeyCode.W)) {
                Player player = new();
                MovePlayer(player.Pos, new Vector3Int(player.Pos.x, player.Pos.y + 1));
            } else if (Input.GetKey(KeyCode.S)) {
                Player player = new();
                MovePlayer(player.Pos, new Vector3Int(player.Pos.x, player.Pos.y - 1));
            } else if (Input.GetKey(KeyCode.D)) {
                Player player = new();
                MovePlayer(player.Pos, new Vector3Int(player.Pos.x + 1, player.Pos.y));
            } else if (Input.GetKey(KeyCode.A)) {
                Player player = new();
                MovePlayer(player.Pos, new Vector3Int(player.Pos.x - 1, player.Pos.y));
            }
        }
    }

    public void MovePlayer(Vector3Int from, Vector3Int to) {
        Obstacle obstacle = new();
        if (obstacle.GetObstacle(to) == Obstacle.Type.Enemy) {
            return;
        }
        Terrain terrain = new();
        if (terrain.GetTerrain(to) == Terrain.Type.Wall) {
            return;
        }

        Scout scout = new();
        scout.CreateShadowsAroundPos(from);
        scout.CreateLightAroundPos(to);

        obstacle.MoveObstacle(from, to);
        AnimaPlayer animaPlayer = new();
        animaPlayer.MovePlayer(playerGameObject, from, to);
        Player player = new();
        player.Pos = to;
    }

    public bool MovementInAction {
        get { return movementInAction; }
        set { movementInAction = value; }
    }
}
