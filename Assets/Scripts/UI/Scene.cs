using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
    private void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("Assets/Menu");
        GameObject parent = GameObject.Find("Canvas");
        GameObject menu = Instantiate(prefab, new Vector3(0, 0), parent.transform.rotation, parent.transform);
        menu.name = "Menu";
    }
}
