using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public int amount;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            // Find Playerhealth and GiveHealth method
            FindObjectOfType<PlayerHealth>().GiveHealth(amount);
            
            Debug.Log("Health");
            
            // Destroy after colliding
            Destroy(gameObject);
            return;
        }
    }
}
