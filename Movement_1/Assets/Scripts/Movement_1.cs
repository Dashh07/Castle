using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_1 : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 InputKey;
    float myFloat;
    public float jumpForce;

    public Animator animator;

   

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        InputKey = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    }

    
    void FixedUpdate()
    {
        MovePlayer();      
    }


    void MovePlayer()
    {
        rb.MovePosition((Vector3)transform.position + InputKey * 10 * Time.deltaTime);



        if (InputKey.magnitude >= 0.1f)
        {

            float Angle = Mathf.Atan2(InputKey.x, InputKey.z) * Mathf.Rad2Deg;
            float Smooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, Angle, ref myFloat, 0.1f);

            transform.rotation = Quaternion.Euler(0, Smooth, 0);
        }

        if(InputKey == Vector3.zero)
        {
            animator.SetFloat("Speed", 0f);
        }
        else
        {
            animator.SetFloat("Speed", 0.5f);
        }


    }

  

}
 
