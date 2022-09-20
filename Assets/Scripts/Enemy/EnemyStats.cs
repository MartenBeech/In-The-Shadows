using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    int attack;
    public int Attack {
        get { return attack; }
        set { attack = value; }
    }

    int defense;
    public int Defense {
        get { return defense; }
        set { defense = value; }
    }

    int health;
    public int Health {
        get { return health; }
        set { health = value; }
    }

    int healthMax;
    public int HealthMax {
        get { return healthMax; }
        set { healthMax = value; }
    }

    int speed;
    public int Speed {
        get { return speed; }
        set { speed = value; }
    }

    Vector3Int pos;
    public Vector3Int Pos {
        get { return pos; }
        set { pos = value; }
    }
}
