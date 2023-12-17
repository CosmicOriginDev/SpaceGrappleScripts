using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AlienGateOpen : MonoBehaviour
{
    public GameObject trigger;
    private GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        wall = gameObject.transform.Find("Wall").gameObject;

    }

    // Update is called once per frame
    void Update()
    {

        
            if (trigger.GetComponent<SwitchScript>().Active == true)
            {
                gameObject.GetComponent<Collider>().enabled = false;
                wall.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<Collider>().enabled = true;
                wall.GetComponent<MeshRenderer>().enabled = true;

            }
        
    }
}
