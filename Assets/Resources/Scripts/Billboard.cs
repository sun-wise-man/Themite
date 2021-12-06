using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    private Camera mainCam;
    public bool useStaticBillboard;

    void Start()
    {
        mainCam = Camera.main;
    }

    void LateUpdate()
    {
        // Check if use static
        if(!useStaticBillboard)
        {
            transform.LookAt(mainCam.transform);
        }
        
        else        
        {
            transform.rotation = mainCam.transform.rotation;
        }
        
        // Rotate game object
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
