using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    private GameObject player;
    public bool Active;
    public bool DisableSave;
    private Collider EC;
    // Start is called before the first frame update
    void Start()
    {
        Active = false;
        player = GameObject.Find("Player");
        EC = gameObject.transform.Find("EnemyRepeler").GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < GlobalVars.checkPointRange)
		{
            if(Active == false)
			{
                Active = true;
                gameObject.GetComponent<SaySomething>().Speak();
                player.GetComponent<ResetToCheckPoint>().resetpoint = gameObject.transform.position;
                if (!DisableSave)
                {
                    GameObject.Find("SaveSystem").GetComponent<SaveGame>().SavePoint = gameObject;
                    GameObject.Find("SaveSystem").GetComponent<SaveGame>().Save();
                }

            }
            if (EC != null)
            {
                EC.enabled = true;
            }
        }
        else
		{
            if (EC != null)
            {
                EC.enabled = false;
            }
		}
        



    }
	
}
