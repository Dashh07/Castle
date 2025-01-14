using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleDamage : MonoBehaviour
{

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null && gameObject.CompareTag("Player"))
        {
            health.TakeDamage(30);
            Debug.Log("Damage");
        }
        
    }
}



