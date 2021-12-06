using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))   
        {
            // Count saved villager
            FindObjectOfType<VillagerCounter>().CountSaved();
            
            // Show UI
            FindObjectOfType<UIBehaviour>().SavedVillager();

            // Sound
            FindObjectOfType<AudioManager>().Play("VillagerSaved");

            // Destroy
            Destroy(gameObject);
            return;
        } 
    }
}
