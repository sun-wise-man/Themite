using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;

    public GameObject player;

    private void OnCollisionEnter(Collision other) {
        
        // Condition if collide with 'player'
        if(other.collider.CompareTag("Player"))
        {
            // Damage the player
            player.GetComponent<PlayerHealth>().DamagePlayer(damage);
        }
    }
}
