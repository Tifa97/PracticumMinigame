using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] ParticleSystem bleedingParticles = null;
    public static event Action OnEnemyDied;

    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Bleed();

        if (currentHealth <= 0f)
        {
            OnEnemyDied?.Invoke();
            gameObject.GetComponent<PoolableObject>().ReturnToPool();
        }
    }

    private void Bleed()
    {
        bleedingParticles.Play();
    }

    private void OnEnable()
    {
        currentHealth = totalHealth;
    }
}
