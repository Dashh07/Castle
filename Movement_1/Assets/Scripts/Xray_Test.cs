using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xray_Test : MonoBehaviour
{

    public GameObject capsule;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.X))
        {
            int LayerIgnore = LayerMask.NameToLayer("Xray");
            capsule.layer = LayerIgnore;
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            int LayerIgnore = LayerMask.NameToLayer("Default");
            capsule.layer = LayerIgnore;
        }
    }
}