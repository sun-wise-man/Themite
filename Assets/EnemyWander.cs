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
        GetComponent<EnemyFollow>().animator.SetBool("isWalking", false);

        if (timer >= wanderTimer && !GetComponent<EnemyFollow>().agro)
        {
            Vector3 newPos = RandomNavSphere(this.transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;

            GetComponent<EnemyFollow>().animator.SetBool("isWalking", true);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
}