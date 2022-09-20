using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    static int attack;
    public int Attack {
        get { return attack; }
        set { attack = value; }
    }

    static int defense;
    public int Defense {
        get { return defense; }
        set { defense = value; }
    }

    static int health;
    public int Health {
        get { return health; }
        set { health = value; }
    }

    int healthMax;
    public int HealthMax {
        get { return healthMax; }
        set { healthMax = value; }
    }

    static int speed;
    public int Speed {
        get { return speed; }
        set { speed = value; }
    }

    static int clarity;
    public int Clarity {
        get { return clarity; }
        set { clarity = value; }
    }

    static int scent = 5;
    public int Scent {
        get { return scent; }
        set { scent = value; }
    }
}
