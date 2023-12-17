using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavBalls : MonoBehaviour
{
    private GameObject player;
    public float w;
    private CameraOrbit CO;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Main Camera");
        CO = player.GetComponent<CameraOrbit>();
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.rotation = CO.rotation;
    }

}
