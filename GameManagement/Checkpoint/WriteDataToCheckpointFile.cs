using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WriteDataToCheckpointFile : MonoBehaviour
{
	// Start is called before the first frame update
	private void Start()
	{
		string path = "Assets/StreamingAssets/CheckpointData.txt"; //Get Path
		StreamWriter w = File.AppendText(path);
		//Find all checkpoints
		GameObject[] Checkpoints = GameObject.FindGameObjectsWithTag("Respawn");
		foreach (GameObject item in Checkpoints)
		{
			w.WriteLine(item.GetComponent<RecordCheckpointData>().Data);
		}
		w.Close();
	}
}
