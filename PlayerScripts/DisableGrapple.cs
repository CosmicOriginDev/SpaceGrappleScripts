using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGrapple : MonoBehaviour
{
    public bool GrappleEnabled;
    // Start is called before the first frame update
    void Start()
    {
        GrappleEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	private void OnTriggerStay(Collider collision)
	{
		if(collision.gameObject.layer == 11)
		{
            GrappleEnabled = false;
        }
       
	}
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == 11)
        {
            GrappleEnabled = true;
        }
        
    }
}
