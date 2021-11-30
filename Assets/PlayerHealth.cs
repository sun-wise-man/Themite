using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    int health;

    public HealthBar healthBar;
    public PauseBehaviour retryBehaviour;

    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void DamagePlayer(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health < damage)
            retryBehaviour.GameOverScreen();
            //Debug.Log("Dead");
    }

    public void GiveHealth(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthBar.SetHealth(health);
    }
}
