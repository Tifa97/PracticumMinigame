using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public static event Action OnEnemyDied;

    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            OnEnemyDied?.Invoke();
            gameObject.GetComponent<PoolableObject>().ReturnToPool();
        }
    }

    private void OnEnable()
    {
        currentHealth = totalHealth;
    }
}
