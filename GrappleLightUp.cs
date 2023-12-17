using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GrappleLightUp : MonoBehaviour
{
    public Material OFFMat;
    public Material ONMat;
  
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, GameObject.Find("Player").transform.position) <= range)
		{
            gameObject.GetComponent<MeshRenderer>().material = ONMat;
		}
        else
		{
            gameObject.GetComponent<MeshRenderer>().material = OFFMat;
		}
    }
}
