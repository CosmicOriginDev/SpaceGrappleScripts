﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMessages : MonoBehaviour
{
    private GameObject Message;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        Message = GameObject.Find("MessageSystem");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Respawn") != null)
        {
            if (Vector3.Distance(FindClosestCheckpoint().transform.position, gameObject.transform.position) < GlobalVars.checkPointRange)
            {
                Message.GetComponent<Text>().text = "CHECKPOINT DETECTED\nPROGRESS SAVED\nPRESS R TO TELEPORT";

            }
            else
            {
                Message.GetComponent<Text>().text = "";

            }
        }
		
    }

    public GameObject FindClosestCheckpoint()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Respawn");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        
        return closest;
        
    }
}
