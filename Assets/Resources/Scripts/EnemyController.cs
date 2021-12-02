using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int enemiesLeft = 0;
    public UIBehaviour uIBehaviour;

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
        if (enemiesLeft <= 0) Invoke("WonScreen", 1f);
    }

    void WonScreen()
    {
        uIBehaviour.WonScreen();
    }
}
