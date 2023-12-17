using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
	
	public void NewGame()
	{

		PlayerPrefs.SetInt("ChkPtID", 0);
		PlayerPrefs.SetInt("GrappleGun", 0);
		PlayerPrefs.SetInt("Grenades", 0);
		PlayerPrefs.SetInt("Level", 0);
		PlayerPrefs.Save();
		GameObject.Find("InitiateCheckpoints").GetComponent<GenerateCheckpointPlayerPrefsOnNewGame>().Initiate();

	}
   
}
