using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class RecordCheckpointData : MonoBehaviour
{
    public float[] Data;
    public bool Recorded;
    public int WhichOne;
    public int Level;
	// Start is called before the first frame update
   
    void Awake()
    {
        Recorded = false;
        float x = gameObject.transform.position.x; // x
        float y = gameObject.transform.position.y; // y
        float z = gameObject.transform.position.z; // z
        int i = WhichOne;
        int l = Level; //CurrentLevel
        PlayerPrefs.SetInt(i.ToString() + "L", Level);
        PlayerPrefs.SetFloat(i.ToString() + "X", x);
        PlayerPrefs.SetFloat(i.ToString() + "Y", y);
        PlayerPrefs.SetFloat(i.ToString() + "Z", z);

        Recorded = true;

    }



}
