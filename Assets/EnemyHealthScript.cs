using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public float health;
    public GameObject deathEffect;
    
    public void TakeDamage(int projectileDamage)
    {
        //Debug.Log("TakeDamage!");
        health -= projectileDamage;
        GetComponent<EnemyFollow>().agro = true;

        if (health <= 0f) Die();
    }

    void Die()
    {
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
    
}
