using UnityEngine;

public class RB_PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float movementMultiplier = 10f;
    public float rbGroundDrag = 6f;
    public float rbAirDrag = 2f;
    public Animator camAnim;

    float playerHeight = 2f;

    float horizontalAxis;
    float verticalAxis;
    bool isWalking;
    bool isGrounded;

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
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.01f);
                
        GetInput();
        ControlDrag();
        CheckForBobbing();

        camAnim.SetBool("isWalking", isWalking);
    }

    void ControlDrag()
    {
        if(isGrounded)
        {
            rb.drag = rbGroundDrag;
        }
        else
        {
            rb.drag = rbAirDrag;
            rb.AddForce(Vector3.down, ForceMode.Force);
        }
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
        if(rb.velocity.magnitude > 0.9f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

}
