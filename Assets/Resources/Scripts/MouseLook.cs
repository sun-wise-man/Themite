using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerBody;
    
    private float xMousePos;
    private float yMousePos;
    private float xRotation;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GetInput();
        RotatePlayer();
    }

    void GetInput()
    {
        xMousePos = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        yMousePos = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
    }

    void RotatePlayer()
    {
        xRotation -= yMousePos;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * xMousePos);
    }

}
