using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    int enemiesMoving = 0;
    public int EnemiesMoving {
        get { return enemiesMoving; }
        set { enemiesMoving = value; }
    }

    public void MoveEnemies() {
        Obstacle obstacle = new();
        EnemyMovement enemyMovement = new();
        AnimaEnemy animaEnemy = new();

        Player player = new();
        for (int x = -player.Scent; x <= player.Scent; x++) {
            for (int y = -player.Scent; y <= player.Scent; y++) {
                if (obstacle.GetObstacle(new Vector3Int(x, y)) == Obstacle.Type.Enemy) {
                    MoveEnemyTowardsPos(new Vector3Int(x, y), player.Pos, enemyMovement, animaEnemy);
                }
            }
        }
        
        if (enemyMovement.EnemiesMoving == 0) {
            Game game = new();
            game.NewTurnPlayer();
        }
    }
    public void MoveEnemyTowardsPos(Vector3Int from, Vector3Int to, EnemyMovement enemyMovement, AnimaEnemy animaEnemy) {
        List<Vector3Int> directions = new();
        Obstacle obstacle = new();
        if (to.x < from.x && obstacle.GetObstacle(to) == Obstacle.Type.Null) {
            directions.Add(new Vector3Int(-1, 0));
        }
        if (to.x > from.x && obstacle.GetObstacle(to) == Obstacle.Type.Null) {
            directions.Add(new Vector3Int(1, 0));
        }
        if (to.y < from.y && obstacle.GetObstacle(to) == Obstacle.Type.Null) {
            directions.Add(new Vector3Int(0, -1));
        }
        if (to.y > from.y && obstacle.GetObstacle(to) == Obstacle.Type.Null) {
            directions.Add(new Vector3Int(0, 1));
        }

        if (directions.Count > 0) {
            Rng rng = new();
            Vector3Int direction = directions[rng.Range(0, directions.Count)];

            Enemy enemy = new();
            GameObject gameObject = GameObject.Find(enemy.GetName(from));
            
            animaEnemy.MoveEnemy(gameObject, from, from + direction);
            enemyMovement.EnemiesMoving++;
        }
    }
}
