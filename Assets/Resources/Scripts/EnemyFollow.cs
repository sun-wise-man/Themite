using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent navMeshEnemy;
    public float agroRange;
    public Animator animator;

    [HideInInspector]
    public bool agro;
    
    GameObject player;
    float distance;

    void Awake() {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // Distance between player and enemy
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        
        // Condition player pos less-than range OR is enemy agro to player
        if (distance <= agroRange || agro) 
        {
            Chase();
            GetComponent<EnemyWander>().isWander = false;
        }
        
        else 
        {
            GetComponent<EnemyWander>().isWander = true;
        
            animator.SetBool("isWalking", false);
        }
    }

    public void Chase()
    {        
        // Set target to player
        navMeshEnemy.SetDestination(player.transform.position);
        
        animator.SetBool("isWalking", true);
    }
}
