using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateCheckpointPlayerPrefsOnNewGame : MonoBehaviour
{
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		

	}
	public void Initiate()
	{
		for (int i = 2; i < 6; i++)
		{
			SceneManager.LoadScene(i);
		}
		SceneManager.LoadScene(1);
		PlayerPrefs.Save();
	}
}
