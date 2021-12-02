using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    [SerializeField] float speed = 3f;
    [SerializeField] float waitTime = 3f;
    float currentWaitTime =0f;

    //mapping 
    float minX, minZ, maxX, maxZ;
    Vector3 moveSpot;
    private void GetGroundSize(){
        GameObject ground = GameObject.FindWithTag("Ground");//tandai nama field dari wilayahnya
        Renderer groundsize = ground.GetComponent<Renderer>();
        minX = (groundsize.bounds.center.x - groundsize.bounds.extents.x);
        maxX = (groundsize.bounds.center.x + groundsize.bounds.extents.x);
        minZ = (groundsize.bounds.center.z - groundsize.bounds.extents.z);
        maxZ = (groundsize.bounds.center.z + groundsize.bounds.extents.z);
    }

    Vector3 GetNewPosition(){
        float randomX = Random.Range(minX,maxX);
        float randomZ = Random.Range(minZ,maxZ);
        Vector3 newPosition = new Vector3(randomX,transform.position.y,randomZ);
        return newPosition;

    }

    //movement 
    void GetToStepping(){
        transform.position = Vector3.MoveTowards(transform.position,moveSpot,speed* Time.deltaTime);
        if(Vector3.Distance(transform.position,moveSpot)< 0.2f){
            if(currentWaitTime <=0){
                moveSpot = GetNewPosition();
                currentWaitTime = waitTime;
                }
            else{
                currentWaitTime -= Time.deltaTime;
            }
        }
    }

    void WatchYourStep(){
        Vector3 targetDirection = moveSpot - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection,0.3f,0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    // Start is called before the first frame update
    void Start()
    {
        GetGroundSize();
        moveSpot = GetNewPosition();
    }

    // Update is called once per frame
    void Update()
    {
        WatchYourStep();
        GetToStepping();
    }
}
