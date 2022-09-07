using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public void MoveEnemyTowardsPos(Vector3Int from, Vector3Int to) {
        List<char> directions = new();
        Obstacle obstacle = new();
        if (to.x < from.x && obstacle.GetObstacle(to) == Obstacle.Type.Null) {
            directions.Add('W');
        }
        if (to.x > from.x && obstacle.GetObstacle(to) == Obstacle.Type.Null) {
            directions.Add('E');
        }
        if (to.y < from.y && obstacle.GetObstacle(to) == Obstacle.Type.Null) {
            directions.Add('S');
        }
        if (to.y > from.y && obstacle.GetObstacle(to) == Obstacle.Type.Null) {
            directions.Add('N');
        }

        if (directions.Count > 0) {
            Rng rng = new();
            char direction = directions[rng.Range(0, directions.Count)];


        }
    }
}
