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
    public int Speed {
        get { return speed; }
        set { speed = value; }
    }

    static Alignment turn;
    public Alignment Turn {
        get { return turn; }
        set { turn = value; }
    }

    public void NewTurnPlayer() {
        turn = Alignment.Player;
    }

    public void NewTurnEnemy() {
        turn = Alignment.Enemy;
        EnemyMovement enemyMovement = new();
        enemyMovement.MoveEnemies();
    }
}
