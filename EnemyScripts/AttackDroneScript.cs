using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDroneScript : MonoBehaviour
{
	public float speed;
	private Transform T;
	private GameObject player;
	private Rigidbody Rb;
	private Collider Col;
	// Start is called before the first frame update
	private void Start()
	{
		T = gameObject.transform;
		Rb = gameObject.GetComponent<Rigidbody>();
		player = GameObject.Find("Player");
		Col = gameObject.GetComponent<Collider>();
	}

	// Update is called once per frame
	void FixedUpdate()
    {
		Chase();
	}

	private void Chase()
	{
		float Playerspeed = player.GetComponent<Rigidbody>().velocity.magnitude;
		T.LookAt(player.transform);
		Rb.velocity = T.forward * Playerspeed * speed;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject != player)
		{
			Col.isTrigger = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
			Col.isTrigger = false;
	}
}
