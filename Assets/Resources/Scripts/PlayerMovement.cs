using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <summary>
// Unused.
// Variation of player movement using CharacterController
// Unused because I don't know how to set its drag value
// </summary>

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10f;
    private CharacterController charCtrl;
    public Animator camAnim;
    private bool isWalking;

    private Vector3 inputVector;
    private Vector3 moveVector;
    private float gravity = -8f;

    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        GetInput();
        MovePlayer();
        CheckForHeadBobbed();

        camAnim.SetBool("isWalking", isWalking);
    }

    void GetInput()
    {
        //Get Keyboard Axis
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        moveVector = (inputVector * playerSpeed) + (Vector3.up * gravity);
    }

    void MovePlayer()
    {
        charCtrl.Move(moveVector * Time.deltaTime);
    }

    void CheckForHeadBobbed()
    {
        if (charCtrl.velocity.magnitude > 0.01f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
}
