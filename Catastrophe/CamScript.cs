using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public GameObject CAM1Obj;
    public GameObject CAM2Obj;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Procedure());
    }

    IEnumerator Procedure()
	{
        CAM2Obj.GetComponent<Cinemachine.CinemachineSmoothPath>().enabled = true;
        yield return null;
	}
}
