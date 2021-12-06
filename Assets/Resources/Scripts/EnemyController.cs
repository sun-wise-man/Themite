using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public TMP_Text enemyCondText;
    
    int enemiesLeft = 0;

    public void CountEnemy()
    {
        // Count enemy-tag game object and add it to an array
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        // Count the length of an array
        enemiesLeft = enemies.Length;
    }

    public void CountDie()
    {
        // Reduce count if enemy dead
        enemiesLeft--;

        // Condition if player defeated all the enemy
        if (enemiesLeft <= 0) 
        {
            UIBehaviour.enemyBool = true;
            enemyCondText.fontStyle = FontStyles.Strikethrough;
            Invoke("WonScreen", 1.5f);
        }
    }

    void WonScreen()
    {
        FindObjectOfType<UIBehaviour>().WonScreen();
    }
}
