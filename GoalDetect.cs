using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GoalDetect : MonoBehaviour
{
    public bool win;
    public int CurrentLevel;
    public int DestinationCheckpointID;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player")
		{
            if (CurrentLevel < 2)
            {
                win = true;
                PlayerPrefs.SetInt("ChkPtID", DestinationCheckpointID);
                GameObject.Find("SaveSystem").GetComponent<SaveGame>().Save();
                SceneManager.LoadScene(CurrentLevel + 1 + 2);
            }
            else
            { 
                win = true;
                SceneManager.LoadScene("Win");
            }
            
		}
        
	}
    
}
