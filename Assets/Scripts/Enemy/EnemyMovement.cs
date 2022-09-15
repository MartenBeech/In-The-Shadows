using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    static int enemiesMoving = 0;
    public int EnemiesMoving {
        get { return enemiesMoving; }
        set { enemiesMoving = value; }
    }

    public void MoveEnemies() {
        Obstacle obstacle = new();
        Terrain terrain = new();
        EnemyMovement enemyMovement = new();
        AnimaEnemy animaEnemy = new();
        Enemy enemy = new();
        Dungeon dungeon = new();
        Player player = new();
        List<Vector3Int> enemiesToMove = new();

        for (int x = player.Pos.x - player.Scent; x <= player.Pos.x + player.Scent; x++) {
            for (int y = player.Pos.y - player.Scent; y <= player.Pos.y + player.Scent; y++) {
                if (dungeon.IsInsideDungeon(new Vector3Int(x, y))) {
                    if (obstacle.GetObstacle(new Vector3Int(x, y)) == Obstacle.Type.Enemy) {
                        enemiesToMove.Add(new Vector3Int(x, y));
                    }
                }
            }
        }
        
        if (enemiesToMove.Count == 0) {
            Game game = new();
            game.NewTurnPlayer();
        } else {
            foreach (Vector3Int pos in enemiesToMove) {
                MoveEnemyTowardsPos(pos, player.Pos, enemyMovement, animaEnemy, enemy, obstacle, terrain);
            }
        }
    }
    public void MoveEnemyTowardsPos(Vector3Int from, Vector3Int to, EnemyMovement enemyMovement, AnimaEnemy animaEnemy, Enemy enemy, Obstacle obstacle, Terrain terrain) {
        List<Vector3Int> directions = new();

        if (to.x < from.x) {
            if (obstacle.GetPassable(new Vector3Int(from.x - 1, from.y)) && terrain.GetPassable(new Vector3Int(from.x - 1, from.y))) {
                directions.Add(new Vector3Int(-1, 0));
            }
        }
        if (to.x > from.x) {
            if (obstacle.GetPassable(new Vector3Int(from.x + 1, from.y)) && terrain.GetPassable(new Vector3Int(from.x + 1, from.y))) {
                directions.Add(new Vector3Int(1, 0));
            }
        }
        if (to.y < from.y) {
            if (obstacle.GetPassable(new Vector3Int(from.x, from.y - 1)) && terrain.GetPassable(new Vector3Int(from.x, from.y - 1))) {
                directions.Add(new Vector3Int(0, -1));
            }
        }
        if (to.y > from.y) {
            if (obstacle.GetPassable(new Vector3Int(from.x, from.y + 1)) && terrain.GetPassable(new Vector3Int(from.x, from.y + 1))) {
                directions.Add(new Vector3Int(0, 1));
            }
        }

        if (directions.Count > 0) {
            Rng rng = new();
            Vector3Int direction = directions[rng.Range(0, directions.Count)];
            Vector3Int newPos = from + direction;

            GameObject gameObject = GameObject.Find(enemy.GetName(from));
            
            animaEnemy.MoveEnemy(gameObject, from, newPos);
            gameObject.name = enemy.GetName(newPos);
            obstacle.MoveObstacle(from, newPos);

            enemyMovement.EnemiesMoving++;
        }
    }
}
