using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100;
    bool isDead = false;
    public bool IsDead { get => isDead; }

    public void TakeDamage(float damage)
    {

        BroadcastMessage("OnDamageTaken");

        health -= damage;
        if (health <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        if (isDead)
            return;

        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }

}
