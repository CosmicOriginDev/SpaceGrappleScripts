using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveGame : MonoBehaviour
{
	public int Level;
	public GameObject SavePoint;
	public void Save()
	{
		GameObject player = GameObject.Find("Player");
		Level = SavePoint.GetComponent<RecordCheckpointData>().Level;
		if (GameObject.Find("Goal").GetComponent<GoalDetect>().win == false)
		{
			PlayerPrefs.SetInt("ChkPtID", SavePoint.GetComponent<RecordCheckpointData>().WhichOne);
		}
		PlayerPrefs.SetInt("Level", Level);
		int IsCheckpointAlreadyActive = (GlobalVars.AnyCheckActive == true) ? 1 : 0; //Convert Int to Bianary for storage
		PlayerPrefs.SetInt("IsCheckpointAlreadyActive", IsCheckpointAlreadyActive);
		//Save Items
		int GrappleGun = (player.GetComponent<StoreUpgrades>().GrappleGun == true) ? 1 : 0; //Convert Int to Bianary for storage
		PlayerPrefs.SetInt("GrappleGun", GrappleGun);
		int Grenades = (player.GetComponent<StoreUpgrades>().Grenades== true) ? 1 : 0; //Convert Int to Bianary for storage
		PlayerPrefs.SetInt("Grenades", Grenades);
		PlayerPrefs.Save();

	}
}
