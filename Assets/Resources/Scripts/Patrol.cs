using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <summary>
// Unused.
// Variation of patrol/wander AI for enemy with out NavMesh
// </summary>

public class Patrol : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float waitTime = 3f;
    float currentWaitTime =0f;

    //mapping 
    float minX, minZ, maxX, maxZ;
    Vector3 moveSpot;
    
    void Start()
    {
        GetGroundSize();
        moveSpot = GetNewPosition();
    }

    void Update()
    {
        MoveNewPosition();
        
        // RotateGameObject();
    }

    private void GetGroundSize()
    {
        // tandai nama field dari wilayahnya
        GameObject ground = GameObject.FindWithTag("Ground");
        
        // Map the ground
        Renderer groundsize = ground.GetComponent<Renderer>();
        
        minX = (groundsize.bounds.center.x - groundsize.bounds.extents.x);
        maxX = (groundsize.bounds.center.x + groundsize.bounds.extents.x);
        minZ = (groundsize.bounds.center.z - groundsize.bounds.extents.z);
        maxZ = (groundsize.bounds.center.z + groundsize.bounds.extents.z);
    }

    Vector3 GetNewPosition()
    {
        float randomX = Random.Range(minX,maxX);
        float randomZ = Random.Range(minZ,maxZ);
        
        // New random posiiton
        Vector3 newPosition = new Vector3(randomX, transform.position.y, randomZ);
        return newPosition;
    }

    //Move
    void MoveNewPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot,speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, moveSpot) < 0.2f)
        {
            if (currentWaitTime <= 0)
            {
                moveSpot = GetNewPosition();
                currentWaitTime = waitTime;
            }
            
            else
            {
                currentWaitTime -= Time.deltaTime;
            }
        }
    }

    void RotateGameObject()
    {
        // Rotate game object toward new direction
        Vector3 targetDirection = moveSpot - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 0.3f, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }    
}
