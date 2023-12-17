using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public float WriteCheckPointRange;
    public static float checkPointRange;
	public bool WriteAnyCheckActive;
	public static bool AnyCheckActive;

	
	private void Update()
	{
		checkPointRange = WriteCheckPointRange;
		//AnyCheckActive = WriteAnyCheckActive;
	}
	


}

