using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public bool Active;
    private GameObject PlayerGrapple;
    public Rigidbody WhatPlayerGrapples;
    // Start is called before the first frame update
    void Start()
    {
        PlayerGrapple = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        WhatPlayerGrapples = PlayerGrapple.GetComponent<SpringJoint>().connectedBody;
        //Check if the player grappled to my ridgidbody
        if (WhatPlayerGrapples == gameObject.GetComponent<Rigidbody>()) 
		{
            Active = true; //Activate me
		}
        if(PlayerGrapple.GetComponent<ResetToCheckPoint>().reset == true) //Deactivate me if the player resets or dies
		{
            Active = false;
		}
    }
}
