using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public int GetDistanceTiles(Vector3Int from, Vector3Int to) {
        int xDiff = Mathf.Abs(from.x - to.x);
        int yDiff = Mathf.Abs(from.y - to.y);
        return xDiff + yDiff;
    }

    public int GetDistanceDiagonally(Vector3Int from, Vector3Int to) {
        int xDiff = Mathf.Abs(from.x - to.x);
        int yDiff = Mathf.Abs(from.y - to.y);
        if (xDiff > yDiff) {
            return xDiff;
        }
        return yDiff;
    }
}
