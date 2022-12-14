using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum Type {
        Normal, Elite, Boss
    }
   
    public void CreateEnemies(int size) {
        Terrain terrain = new();
        List<Vector3Int> paths = terrain.GetAllPathTiles(size);
        Rng rng = new();
        for (int i = 0; i < size / 2; i++) {
            int rnd = rng.Range(0, paths.Count);
            CreateEnemy(Type.Normal, paths[rnd]);
            paths.RemoveAt(rnd);
        }
    }

    public void CreateEnemy(Type type, Vector3Int pos) {
        GameObject prefab = Resources.Load<GameObject>("Assets/Enemy");
        GameObject parent = GameObject.Find("Enemies");
        GameObject enemy = Instantiate(prefab, new Vector3(pos.x * Tile.TILE_SIZE, pos.y * Tile.TILE_SIZE, -1), parent.transform.rotation, parent.transform);
        enemy.name = GetName(pos);
        enemy.GetComponent<EnemyStats>().Pos = pos;

        Obstacle obstacle = new();
        obstacle.CreateEnemy(pos);

        EnemyUI enemyUI = new();
        enemyUI.UpdateText(enemy);
    }

    public string GetName(Vector3Int pos) {
        return $"Enemy{pos.x}-{pos.y}";
    }

    public void EnemyClicked(GameObject gameObject) {
        Player player = new();
        Distance distance = new();
        Game game = new();
        if (distance.GetDistanceTiles(player.Pos, gameObject.GetComponent<EnemyStats>().Pos) <= 1 &&
            game.Turn == Game.Alignment.Player) {
            PlayerCombat playerAttack = new();
            playerAttack.AttackEnemy(gameObject);
        }
    }
}
