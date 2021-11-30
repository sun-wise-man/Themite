using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;

    public GameObject player;

    // private void Awake() {
    //     player = GameObject.FindGameObjectWithTag("Player");
    // }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Player"))
        {
            player.GetComponent<PlayerHealth>().DamagePlayer(damage);
        }
    }
}
