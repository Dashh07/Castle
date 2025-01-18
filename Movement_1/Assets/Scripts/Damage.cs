using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Damage : MonoBehaviour
{
     public Animator animator;
     public GameObject slash;
     BoxCollider BoxCollider;
    public Transform sword;
   
    private void Start()
    {
        BoxCollider = GetComponent<BoxCollider>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (gameObject.CompareTag("Sword") && health != null)
        {
            Debug.Log("Damage");
            Instantiate(slash, sword.position, Quaternion.identity);
            BoxCollider.enabled = true;
            animator.SetTrigger("isHurt");
            health.TakeDamage(30);


        }
        if (health = null)
        {
            return;
        }


    }

}

