using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius;
    public float attackRadius;
    public Animator animator;
    Transform target;
    NavMeshAgent agent;
    BoxCollider boxCollider;
    
    

     //Start is called before the first frame update
    void Start()
    {
        //target = GameObject.Find("Player").transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider>();
    }

    // Update is called once per frame
   void Update()
   {
       float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius && !animator.GetCurrentAnimatorStateInfo(0).IsName("Mutant_Walk"))
       {
           animator.SetBool("isWalking", true);
           agent.SetDestination(target.position);


        }
       else if(distance >= lookRadius)
       {
           animator.SetBool("isWalking", false);
        }
       
       if (distance <= attackRadius)
       {
           Attack();
            
        }


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, attackRadius);

    }

    private void Attack()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Mutant_Attack"))
        {
            animator.SetTrigger("Attack");
            agent.SetDestination(transform.position);
            
        }

    }

    void EnableAttack()
    {
        boxCollider.enabled = true;
    }
    void DisableAttack()
    {
        boxCollider.enabled = false;
    }

     void OnTriggerEnter(Collider other)
    {
        PlayerHealth pHealth = other.gameObject.GetComponent<PlayerHealth>();
        
        if(other.gameObject.CompareTag("Player") && pHealth != null)
        {
            pHealth.TakeDamage(30);
        }
       
      


   }
}



