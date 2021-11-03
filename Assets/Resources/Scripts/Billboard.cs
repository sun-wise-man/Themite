using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    private Camera mainCam;
    public bool useStaticBillboard;


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
