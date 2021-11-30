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
    public bool agro;
    
    float distance;
    bool isWalking;

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        
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
        isWalking = true;
        navMeshEnemy.isStopped = false;
        navMeshEnemy.SetDestination(player.transform.position);
    }
}
