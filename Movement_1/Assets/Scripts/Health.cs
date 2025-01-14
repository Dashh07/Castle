using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   public float maxHealth = 100;
   public float currentHealth;
   public GameObject FloatingText;
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
        ShowFloatingText();

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if(currentHealth == 0)
        {
            Animator.SetTrigger("isDead");
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, 5f);
        }

    }

    void ShowFloatingText()
    {
        var go = Instantiate(FloatingText, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = currentHealth.ToString();
    }

}
