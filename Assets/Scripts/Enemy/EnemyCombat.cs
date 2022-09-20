using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCombat : MonoBehaviour
{
    public void TakeDamage(GameObject gameObject, int amount) {
        int health = gameObject.GetComponent<EnemyStats>().Health;
        health -= amount;

        if (health <= 0) {
            Die(gameObject);
        }
    }

    public void Die(GameObject gameObject) {
        Destroy(gameObject);
    }
}
