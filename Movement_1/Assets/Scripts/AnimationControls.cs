using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControls : MonoBehaviour
{
    [SerializeField]
    public Animator playerAnim;


    //Equip-Unequip parameters
    [SerializeField]
    public GameObject sword;
    [SerializeField]
    public GameObject swordOnShoulder;
    public bool isEquipping;
    public bool isEquipped;

    //Blocking parameters
    public bool isBlocking;

    //Kicking parameters
    public bool isKicking;


    //Attack Parameters
    public bool isAttacking;
    private float timeSinceAttack;
    public int currentAttack = 0;

    public Transform Sword;
    public GameObject slash;



    // Update is called once per frame
    void Update()
    {
        timeSinceAttack += Time.deltaTime;

        Attack();
        Equip();
        Block();
        Kick();
    }


    private void Equip()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isEquipping = true;
            playerAnim.SetTrigger("Equip");
        }
    }

    public void ActiveWeapon()
    {
        if (!isEquipped)
        {
            sword.SetActive(true);
            swordOnShoulder.SetActive(false);
            isEquipped = !isEquipped;
        }
        else
        {
            sword.SetActive(false);
            swordOnShoulder.SetActive(true);
            isEquipped = !isEquipped;
        }
    }

    public void Equipped()
    {
        isEquipping = false;
    }

    private void Block()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            playerAnim.SetBool("Block", true);
            isBlocking = true;
        }
        else
        {
            playerAnim.SetBool("Block", false);
            isBlocking = false;
        }
    }

    public void Kick()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerAnim.SetBool("Kick", true);
            isKicking = true;
        }
        else
        {
            playerAnim.SetBool("Kick", false);
            isKicking = false;
        }
    }

    private void Attack()
    {

        if (Input.GetMouseButtonDown(0)&& timeSinceAttack > 0.8f)
        {
            if (!isEquipped)
                return;

            currentAttack++;
            isAttacking = true;

            if (currentAttack > 3)
                currentAttack = 1;

            //Reset
            if (timeSinceAttack > 1.5f)
                currentAttack = 1;
           
            //Call Attack Triggers
            playerAnim.SetTrigger("Attack" + currentAttack);

            //Reset Timer
            timeSinceAttack = 0;

          

        }


    }

    public void ResetAttack()
    {
        isAttacking = false;
    }
}
