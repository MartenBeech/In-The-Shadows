using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    void Update() {
        Cam.cam.transform.position = player.transform.position + offset;

        if (Input.mouseScrollDelta.y > 0) {
            if (Cam.cam.GetComponentInChildren<Camera>().orthographicSize > 100) {
                Cam.cam.GetComponentInChildren<Camera>().orthographicSize /= 1.1f;
            }
        } else if (Input.mouseScrollDelta.y < 0) {
            if (Cam.cam.GetComponentInChildren<Camera>().orthographicSize < 1000) {
                Cam.cam.GetComponentInChildren<Camera>().orthographicSize *= 1.1f;
            }
        }
    }
}
