using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cam : MonoBehaviour
{
    public static GameObject cam;

    private void Start() {
        cam = GameObject.Find("Main Camera");
    }
    public void SetPosition(Vector3 pos) {
        cam.transform.position = new Vector3(pos.x, pos.y, -10);
    }
}
