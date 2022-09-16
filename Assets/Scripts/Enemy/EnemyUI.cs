using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public void UpdateText(GameObject gameObject) {
        Transform attackText = gameObject.transform.Find("AttackText");
        attackText.GetComponent<Text>().text = gameObject.GetComponentInChildren<EnemyStats>().Attack.ToString();
        Transform defenseText = gameObject.transform.Find("DefenseText");
        attackText.GetComponent<Text>().text = gameObject.GetComponentInChildren<EnemyStats>().Defense.ToString();
        Transform healthText = gameObject.transform.Find("HealthText");
        attackText.GetComponent<Text>().text = gameObject.GetComponentInChildren<EnemyStats>().Health.ToString();
        Transform speedText = gameObject.transform.Find("SpeedText");
        attackText.GetComponent<Text>().text = gameObject.GetComponentInChildren<EnemyStats>().Speed.ToString();
    }
}
