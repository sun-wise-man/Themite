using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public GameObject deathEffect;
    public GameObject itemPickup;
    GameObject spawner;

    private void Start() {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

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
        Instantiate(itemPickup, transform.position, Quaternion.identity);
        spawner.GetComponent<EnemyController>().CountDie();
    }

}
