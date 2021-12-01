using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent navMeshEnemy;
    public Animator animator;
    public float agroRange;

    [HideInInspector]
    public bool agro;
    
    float distance;
    bool isWalking;

    void Update()
    {
        // Distance between player and enemy
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        
        // Condition player pos <= range or is enemy agro
        if (distance <= agroRange || agro) 
        {
            Chase();
        }
        
        else 
        {
            navMeshEnemy.isStopped = true;
            isWalking = false;
        }

        animator.SetBool("isWalking", isWalking);
    }

    public void Chase()
    {
        // Animator bool
        isWalking = true;
        
        // Stop enemy movement
        navMeshEnemy.isStopped = false;
        
        // Set target to player
        navMeshEnemy.SetDestination(player.transform.position);
    }
}
