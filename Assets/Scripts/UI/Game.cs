using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public enum Alignment {
        Player, Enemy
    }

    static int speed = 4;
    static Alignment turn;

    public int Speed {
        get { return speed; }
        set { speed = value; }
    }

    

    public Alignment Turn {
        get { return turn; }
        set { turn = value; }
    }
}
