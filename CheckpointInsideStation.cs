using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointInsideStation : MonoBehaviour
{
	public bool alreadyDone;
	// Start is called before the first frame update
	private void OnCollisionEnter(Collision collision)
	{
		if (alreadyDone == false)
		{
			if (collision.gameObject == GameObject.Find("Player"))
			{
				GameObject.Find("Player").GetComponent<ResetToCheckPoint>().resetpoint = GameObject.Find("Player").transform.position;
				GameObject.Find("SaveSystem").GetComponent<SaveGame>().Save();
				alreadyDone = true;
			}
		}
	}
}
