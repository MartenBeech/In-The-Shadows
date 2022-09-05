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
        Terrain terrain = new Terrain();
        List<Vector3Int> paths = terrain.GetAllPathTiles(size);
        Rng rng = new Rng();
        for (int i = 0; i < size / 2; i++) {
            int rnd = rng.Range(0, paths.Count);
            CreateEnemy(Type.Normal, paths[rnd]);
            paths.RemoveAt(rnd);
        }
    }

    public void CreateEnemy(Type type, Vector3Int pos) {
        GameObject prefab = Resources.Load<GameObject>("Assets/Enemy");
        GameObject parent = GameObject.Find("Enemies");
        GameObject player = Instantiate(prefab, new Vector3(pos.x * Tile.TILE_SIZE, pos.y * Tile.TILE_SIZE, -1), parent.transform.rotation, parent.transform);
        player.name = GetName(pos.x, pos.y);

        Obstacle obstacle = new Obstacle();
        obstacle.CreateEnemy(pos);
    }

    public string GetName(int x, int y) {
        return $"Enemy{x}-{y}";
    }
}