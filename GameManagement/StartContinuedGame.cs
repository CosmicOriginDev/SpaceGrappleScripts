using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartContinuedGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Awake()
	{
		int ID = PlayerPrefs.GetInt("ChkPtID");
		GameObject.Find("SaveSystem").GetComponent<LoadCheckpointValuesIntoPlayer>().CheckpointID = ID;
		GameObject.Find("SaveSystem").GetComponent<LoadCheckpointValuesIntoPlayer>().LoadThemIntoPlayer();
		GameObject Player = GameObject.Find("Player");
		StoreUpgrades items = Player.GetComponent<StoreUpgrades>();
		items.GrappleGun = (PlayerPrefs.GetInt("GrappleGun") == 1) ? true : false; //convert back to bool
		items.Grenades = (PlayerPrefs.GetInt("Grenades") == 1) ? true : false; //convert back to bool
		GameObject.Find("SaveSystem").GetComponent<SaveGame>().Save();
	}
}
