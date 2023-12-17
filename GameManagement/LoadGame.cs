using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
	int Level;
	Vector3 CheckpointCoords;
	public void Load()
	{
			//Retrive Save Data
			int ID = PlayerPrefs.GetInt("ChkPtID");
			int Level = PlayerPrefs.GetInt(ID.ToString() + "L");
			SceneManager.LoadScene(Level+2);
	}
}
