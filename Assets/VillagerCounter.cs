using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VillagerCounter : MonoBehaviour
{
    public TMP_Text villagerCondText;

    int villagerSaved = 0;

    public void CountVillager()
    {
        // Count enemy-tag game object and add it to an array
        GameObject[] villagers = GameObject.FindGameObjectsWithTag("Villager");

        // Count the length of an array
        villagerSaved = villagers.Length;
    }

    public void CountSaved()
    {
        // Reduce count if enemy dead
        villagerSaved--;

        // Condition if player defeated all the enemy
        if (villagerSaved <= 0) 
        {
            UIBehaviour.villagerBool = true;
            villagerCondText.fontStyle = FontStyles.Strikethrough;
            Invoke("WonScreen", 1.5f);
        }
    }

    void WonScreen()
    {
        FindObjectOfType<UIBehaviour>().WonScreen();
    }
}
