using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    private Camera mainCam;//ini untuk camera player??
    public bool useStaticBillboard;// informasi status penggunaan static billboard


    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!useStaticBillboard){//untuk aktivasi opsi billboarding
            transform.LookAt(mainCam.transform);
        }else{
            transform.rotation = mainCam.transform.rotation;
        }
        
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
