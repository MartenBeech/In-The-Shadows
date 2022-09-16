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

    int speed;
    public int Speed {
        get { return speed; }
        set { speed = value; }
    }
}
