using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public static event Action OnPlayerDied;
    private bool isAlive = true;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }

    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && isAlive)
        {
            isAlive = false;
            OnPlayerDied?.Invoke();
        }
    }
}
