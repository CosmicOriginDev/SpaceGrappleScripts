using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
	public bool NoSpam;
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider other)
	{
		if (NoSpam == false)
		{
			if (other.gameObject == GameObject.Find("Player"))
			{
				
				gameObject.GetComponent<AudioSource>().Play();
				NoSpam = true;
			}
		}
	}
}
