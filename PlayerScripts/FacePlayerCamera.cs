using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayerCamera : MonoBehaviour
{
    public GameObject camera;
    private CameraOrbit CO;
    // Start is called before the first frame update
    void Start()
    {
        CO = camera.GetComponent<CameraOrbit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Walk>().grounded == false)
        {
            gameObject.transform.rotation = CO.toRotation;
        }
    }
}
