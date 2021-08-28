using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    protected float currentHealth;
    public float totalHealth = 1;

    public abstract void TakeDamage(float damage);

    void Start()
    {
        currentHealth = totalHealth;
    }
}
