using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void StartGameClicked()
    {
        Destroy(GameObject.Find("Menu"));
        Dungeon dungeon = new Dungeon();
        dungeon.CreateDungeon(50);
    }
}
