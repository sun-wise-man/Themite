using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public float health;
    
    public void TakeDamage(int projectileDamage)
    {
        Debug.Log("TakeDamage!");
        health -= projectileDamage;
        if (health <= 0f) Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
    
}
