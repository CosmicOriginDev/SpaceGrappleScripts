using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughGoo : MonoBehaviour
{
    private Collider collider;
    public AmeobaScript Head;
    public bool PassWallsToo;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<Collider>();
        Player = GameObject.Find("Player");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer != 18)
        {
            if (collision.gameObject.tag == "EatGrenades" || Head.Ghostmode == true)
            {
                collider.isTrigger = true;

            }
            if (collision.gameObject != Player && PassWallsToo)
            {
                collider.isTrigger = true;

            }
        }
        if (collision.gameObject.layer == 18)
        {
            collider.isTrigger = false;

        }


    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == 18)
        {
            collider.isTrigger = false;
        }
        else
		{
            if (collision.gameObject.tag == "EatGrenades")
            {
                collider.isTrigger = false;
            }
            if (collision.gameObject == Player && PassWallsToo)
            {
                collider.isTrigger = false;

            }
        }
    }

    
    }
