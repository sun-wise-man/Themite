using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    GameObject player;
    public int amount;

    private void Awake() 
    {
        // Find player
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            // Referenced its GiveHealth method
            player.GetComponent<PlayerHealth>().GiveHealth(amount);
            
            // Destroy after colliding
            Destroy(gameObject);
            return;
        }
    }
}
