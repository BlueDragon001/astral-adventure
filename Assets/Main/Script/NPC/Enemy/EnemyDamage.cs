using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(staticString.enemyTag))
        {
            var enemy = other.GetComponent<Enemy>();
            enemy.isAlive = false;
        }
    }
}
