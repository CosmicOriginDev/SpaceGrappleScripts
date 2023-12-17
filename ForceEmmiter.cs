using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceEmmiter : MonoBehaviour
{
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position,new Vector3(2,2,2));
        Gizmos.DrawRay(transform.position, transform.forward*100);
	}
	private void OnTriggerStay(Collider obj)
	{
		if(obj.GetComponent<Rigidbody>() == true)
		{
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(gameObject.transform.forward * force);
		}
	}
}
