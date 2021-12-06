using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWander : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    public bool isWander;

    NavMeshAgent agent;
    Transform target;
    float timer;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Condition check
        // Make sure the enemy isn't following to player
        if (isWander)
        {
            Invoke("TriggerWander", 2f);
        }        
    }

    public void TriggerWander()
    {
        // Set animation
        GetComponent<EnemyFollow>().animator.SetBool("isWalking", false);

        // Check timer and isn't agro to player
        if (timer >= wanderTimer && !GetComponent<EnemyFollow>().agro)
        {
            // Find new position using RandomNavSphere
            Vector3 newPos = RandomNavSphere(this.transform.position, wanderRadius, -1);
            
            // Set new position
            agent.SetDestination(newPos);
            
            timer = 0;

            // Set animation
            GetComponent<EnemyFollow>().animator.SetBool("isWalking", true);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        // Find random position inside a sphere
        Vector3 randDirection = Random.insideUnitSphere * dist;
        
        // Find the direction between sphere origin and random position
        randDirection += origin;
        
        NavMeshHit navHit;
        
        // Check if new target position and its path walkable
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        // Return the position
        return navHit.position;
    }
}