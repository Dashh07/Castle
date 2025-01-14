using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolpoints;
    public int targetPoint;
    public float speed;
    

    enum states { walk, look}
    private states currentState = states.walk;
    void Start()
    {
        targetPoint = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = patrolpoints[targetPoint].position - transform.position;
        //if (transform.position == patrolpoints[targetPoint].position)
        //{
        //    increaseTargetInt();

        //}
        //transform.position = Vector3.MoveTowards(transform.position,patrolpoints[targetPoint].position,speed *  Time.deltaTime);
        Quaternion rotation = Quaternion.LookRotation(direction);
        //transform.rotation = rotation;
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3f);

        switch (currentState)
        {
            case states.walk:
                transform.position = Vector3.MoveTowards(transform.position, patrolpoints[targetPoint].position, speed * Time.deltaTime);

                if (transform.position == patrolpoints[targetPoint].position)
                {
                    increaseTargetInt();
                    
                    currentState = states.look;
                }
                break;
                case states.look:
                Quaternion savedRotation = transform.rotation;

                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3f);
                if (savedRotation == transform.rotation)
                {
                   
                    currentState = states.walk;
                }
                break;

        }
    }

    void increaseTargetInt()
    {
        targetPoint++;
        if(targetPoint >= patrolpoints.Length)
        {
            targetPoint = 0;
        }
    }
}
