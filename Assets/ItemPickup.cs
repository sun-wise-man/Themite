using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    GameObject player;
    public int amount;

    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("DestroyObject", 10f);

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<PlayerHealth>().GiveHealth(amount);
            Destroy(gameObject);
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
