using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheckpointValuesIntoPlayer : MonoBehaviour
{
	public int CheckpointID;
	private GameObject player;
	// Start is called before the first frame update
	public void LoadThemIntoPlayer()
	{
		Debug.Log("Loaded");
		player = GameObject.Find("Player");
		float x = PlayerPrefs.GetFloat(CheckpointID.ToString() + "X");
		float y = PlayerPrefs.GetFloat(CheckpointID.ToString() + "Y");
		float z = PlayerPrefs.GetFloat(CheckpointID.ToString() + "Z");
		ResetToCheckPoint rtcp;
		rtcp = player.GetComponent<ResetToCheckPoint>();
		rtcp.resetpoint = new Vector3(x, y, z);
		rtcp.reset = true;


	}
}
