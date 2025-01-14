using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Cube"))
        {
            other.transform.SetParent(transform);
   
        }
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("pull");
        }
     
    }
}



