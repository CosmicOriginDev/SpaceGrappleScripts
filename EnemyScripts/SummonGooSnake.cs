using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonGooSnake : MonoBehaviour
{

	private GameObject player;
	public GameObject Goosnake;
	public bool PreventSpam;
	public AmeobaScript SnakeScript;
	// Start is called before the first frame update
	private void Start()
	{
		player = GameObject.Find("Player");
		GameObject.Find("GooSnake").transform.position = new Vector3(0, -1000, 0);
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player && PreventSpam == false)
		{

			GameObject.Find("GooSnake").transform.position = new Vector3(3805.5f, 53.4f, 2237.5f);
			PreventSpam = true;
			SnakeScript.enabled = true;
		}
	}
}
