using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPositionSetter : MonoBehaviour
{


	// Update is called once per frame
	void Update()
	{
		if(GlobalVars.AnyCheckActive == false)
		{
			GameObject.Find("Player").GetComponent<ResetToCheckPoint>().resetpoint = gameObject.transform.position;
			GameObject.Find("Player").transform.position = gameObject.transform.position;
			GlobalVars.AnyCheckActive = true;
		}
		

	}
}
