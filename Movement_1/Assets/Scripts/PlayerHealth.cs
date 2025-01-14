using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Animator Animator;
    bool isDead;

    

    private void Start()
    {
        currentHealth = maxHealth;
        Animator = GetComponent<Animator>();

    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        Animator.SetTrigger("Hurt");

       


        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth == 0)
        {
            Animator.SetTrigger("isDead");
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject,6f);
        }

    }
}
