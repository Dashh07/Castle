using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.VFX;

public class Teleport : MonoBehaviour
{

    [SerializeField] Vector3 offset;
    [SerializeField] GameObject RaystartPoint;
    public GameObject enemy;
    [SerializeField] ParticleSystem sys;
    public float coolDownDuration = 5.0f;
    public float cooldownTimer = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(RaystartPoint.transform.position, RaystartPoint.transform.forward, out RaycastHit hit, 50f, 1<<9) && cooldownTimer <= 0f)
            {
                GameObject enemy = hit.rigidbody.gameObject;
                Vector3 enemyPos = enemy.transform.position;
                teleport(enemyPos);
                
            }
            else if (cooldownTimer > 0f)
            {
                cooldownTimer -= Time.deltaTime;
            }
            
           
        }
        
    }

    

    void teleport(Vector3 pos)
    {
        transform.position = pos;
        transform.rotation = enemy.transform.rotation;
        cooldownTimer = coolDownDuration;

    }

}
