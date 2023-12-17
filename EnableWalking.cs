using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWalking : MonoBehaviour
{
    public GameObject Player;
    private bool StartCheckAlreadyMade;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Player.GetComponent<Walk>().enabled = false;
        GameObject.Find("Bounds").GetComponent<SummonAttackDrones>().enabled = false;
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject == Player)
        {
            Player.GetComponent<Walk>().enabled = true;
            GameObject.Find("Bounds").GetComponent<SummonAttackDrones>().enabled = true;
            if(StartCheckAlreadyMade != true)
			{
                Player.GetComponent<ResetToCheckPoint>().resetpoint = Player.transform.position;
                StartCheckAlreadyMade = true;
			}
        }
    }
}
