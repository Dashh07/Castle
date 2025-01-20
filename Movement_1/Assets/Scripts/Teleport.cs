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
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.F) && cooldownTimer <= 0f)
        {
            if (Physics.Raycast(RaystartPoint.transform.position, RaystartPoint.transform.forward, out RaycastHit hit, 50f, 1<<9))
            {
                GameObject enemy = hit.rigidbody.gameObject;
                Vector3 enemyPos = enemy.transform.position;
                teleport(enemyPos);
                
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
