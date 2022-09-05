using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public const int TILE_SIZE = 100;
    public void CreateTiles(int size)
    {
        GameObject prefab = Resources.Load<GameObject>("Assets/Tile");
        GameObject parent = GameObject.Find("Tiles");
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                GameObject tile = Instantiate(prefab, new Vector3(x * TILE_SIZE, y * TILE_SIZE), parent.transform.rotation, parent.transform);
                tile.name = GetName(x, y);
            }
        }
    }

    public string GetName(int x, int y)
    {
        return $"Tile{x}-{y}";
    }
}
