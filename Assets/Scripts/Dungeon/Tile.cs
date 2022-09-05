using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public void CreateTiles(int size)
    {
        GameObject prefab = Resources.Load<GameObject>("Assets/Tile");
        GameObject parent = GameObject.Find("Tiles");
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                GameObject colorButton = Instantiate(prefab, new Vector3(x * 100, y * 100), parent.transform.rotation, parent.transform);
                colorButton.name = GetName(x, y);
            }
        }
    }

    public string GetName(int x, int y)
    {
        return $"Tile{x}-{y}";
    }
}
