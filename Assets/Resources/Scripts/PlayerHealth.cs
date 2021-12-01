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
        // Set max health
        health = maxHealth;

        // Set maxhealth in healthbar value to max health
        healthBar.SetMaxHealth(maxHealth);
    }

    // Damage the player with 'damage' amount of damage
    public void DamagePlayer(int damage)
    {
        health -= damage;

        // Update healthbar with health (current health)
        healthBar.SetHealth(health);

        // Audio
        FindObjectOfType<AudioManager>().Play("PlayerHit");

        // Death condition
        if (health < damage)
        {
            // Display Game Over
            retryBehaviour.GameOverScreen();

            // Audio
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
        }
    }

    // Add health method
    public void GiveHealth(int amount)
    {
        FindObjectOfType<AudioManager>().Play("HealthUp");

        health += amount;

        // Condition check so current health didn't go over max health
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        // Update healthbar
        healthBar.SetHealth(health);
    }
}
