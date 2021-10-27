using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rbDrag = 6f;
    public float movementMultiplier = 10f;
    public Animator camAnim;
    
    float horizontalAxis;
    float verticalAxis;
    private bool isWalking;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ControlDrag();
        CheckForBobbing();

        camAnim.SetBool("isWalking", isWalking);
    }

    void ControlDrag()
    {
        rb.drag = rbDrag;
    }

    void GetInput()
    {
        //Get keyboard input
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        verticalAxis = Input.GetAxisRaw("Vertical");

        //Move applying axis to transform object
        moveDirection = transform.forward * verticalAxis + transform.right * horizontalAxis;
    }

    //MonoBehaviour.FixedUpdate has the frequency of the physics system
    //This movement is physics-based therefore used FixedUpdate
    private void FixedUpdate() 
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        //Normalizing the diagonal movement vector
    }

    void CheckForBobbing()
    {
        if(rb.velocity.magnitude > 0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
}
