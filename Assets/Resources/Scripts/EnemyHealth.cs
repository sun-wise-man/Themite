using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public GameObject deathEffect;
    public GameObject itemPickup;
    GameObject spawner;

    private void Start() {

        // Find spawner
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    public void TakeDamage(int projectileDamage)
    {
        health -= projectileDamage;

        // Set agro
        GetComponent<EnemyFollow>().agro = true;

        // Audio
        FindObjectOfType<AudioManager>().Play("EnemyHit");

        // Enemy death condition
        if (health <= 0f) Die();
    }

    void Die()
    {
        // Audio
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
        
        // Instantiate particle effect and item drop
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(itemPickup, transform.position, Quaternion.identity);
        
        // Count enemy death in spawner-tag game object
        spawner.GetComponent<EnemyController>().CountDie();
        
        Destroy(gameObject);
        return;
    }

}
