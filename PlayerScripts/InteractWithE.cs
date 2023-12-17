using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithE : MonoBehaviour
{
	public Ray ray;
	public bool PreventSpam;
	// Start is called before the first frame update
	private void Update()
	{
		

		if (Input.GetKeyDown(KeyCode.E)) //If E is pressed
		{
			if (PreventSpam == false)
			{
				ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(screenCenter());
				PreventSpam = true;
			}
		}
		if(Input.GetKeyUp(KeyCode.E))
		{
			PreventSpam = false;
			ray = new Ray();

		}
	}

	public Vector3 screenCenter()
	{
		return (new Vector3(Screen.width / 2, Screen.height / 2, 0));
	}
}
