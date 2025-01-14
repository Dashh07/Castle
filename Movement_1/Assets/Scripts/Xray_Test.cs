using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xray_Test : MonoBehaviour
{

    public GameObject capsule;
    public GameObject image;
    public KeyCode togglekey = KeyCode.X;
    bool isXrayActive = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(togglekey))
        {
            XrayActive();
        }

        
    }

    void XrayActive()
    {
        isXrayActive = !isXrayActive;

        if(isXrayActive)
        {
            int LayerIgnore = LayerMask.NameToLayer("Xray");
            capsule.layer = LayerIgnore;
            image.SetActive(true);
        }
        else
        {
            int LayerIgnore = LayerMask.NameToLayer("Default");
            capsule.layer = LayerIgnore;
            image.SetActive(false);
        }
    }
}
