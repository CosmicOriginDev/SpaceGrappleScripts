using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CallWhenTouched : MonoBehaviour
{
	public GameObject Filter;
	public UnityEvent Output;

	private void OnCollisionEnter(Collision collision)
	{
		if (Filter != null) //Check if there is a filter
		{
			if (collision.gameObject == Filter)
			{
				Output.Invoke();
			}
		}
		else //If no filter, invoke if touched by anything
		{
			Output.Invoke();
		}
	}
		private void OnTriggerEnter(Collider collision)
	{
		if (Filter != null) //Check if there is a filter
		{
			if (collision.gameObject == Filter)
			{
				Output.Invoke();
			}
		}
		else //If no filter, invoke if touched by anything
		{
			Output.Invoke();
		}
	}


}
