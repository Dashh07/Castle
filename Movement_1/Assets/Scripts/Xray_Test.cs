using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xray_Test : MonoBehaviour
{

    public List<GameObject> capsule;
    public GameObject image;
    public KeyCode togglekey = KeyCode.X;
    bool isXrayActive = false;
    public float coolDownDuration = 5.0f;
    public float cooldownTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(togglekey) && cooldownTimer <= 0f)
        {
            XrayActive();
        }

        
    }

    void XrayActive()
    {
        isXrayActive = !isXrayActive;

        if(isXrayActive)
        {
            foreach(GameObject enemy in capsule)
            {
                int LayerIgnore = LayerMask.NameToLayer("Xray");
                enemy.layer = LayerIgnore;
                
            }
            image.SetActive(true);
        }
        else
        {
            foreach (GameObject enemy in capsule)
            {
                int LayerIgnore = LayerMask.NameToLayer("Default");
                enemy.layer = LayerIgnore;
                
            }
            image.SetActive(false);
            cooldownTimer = coolDownDuration;
        }
    }
}
