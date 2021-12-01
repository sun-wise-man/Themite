using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int enemiesLeft = 0;
    public PauseBehaviour pauseBehaviour;

    public void CountEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;
    }

    public void CountDie()
    {
        enemiesLeft--;
        if (enemiesLeft <= 0) Invoke("WonScreen", 1f);
    }

    void WonScreen()
    {
        pauseBehaviour.WonScreen();
    }
}
