using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter(Collision other) {
        
        // Condition if collide with 'player'
        if(other.collider.CompareTag("Player"))
        {
            // Damage the player
            FindObjectOfType<PlayerHealth>().DamagePlayer(damage);
        }
    }
}
