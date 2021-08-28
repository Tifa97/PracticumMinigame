using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{   
    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            gameObject.GetComponent<PoolableObject>().ReturnToPool();
        }
    }

    private void OnEnable()
    {
        currentHealth = totalHealth;
    }
}
