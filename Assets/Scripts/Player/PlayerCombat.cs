using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public void AttackEnemy(GameObject gameObject) {
        PlayerStats playerStats = new();
        int attack = playerStats.Attack;
        int defense = gameObject.GetComponent<EnemyStats>().Defense;

        int damage = attack * (1 - (defense / (10 + defense)));
        EnemyCombat enemyCombat = new();
        enemyCombat.TakeDamage(gameObject, damage);
    }
}
