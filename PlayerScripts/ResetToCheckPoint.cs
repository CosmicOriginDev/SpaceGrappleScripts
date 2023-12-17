using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetToCheckPoint : MonoBehaviour
{
    private GameObject player;
    public bool reset;
    private Rigidbody rigidbody;
    public Vector3 resetpoint;
    public HandMove HandMove;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        rigidbody = player.GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R)) //reset detect
        {
            reset = true;
        }
        if (reset)
        {
            HandMove.BreakGrappleNoSound();
            rigidbody.velocity = Vector3.zero;
            player.transform.position = resetpoint;
            rigidbody.velocity = Vector3.zero; //reset procedure
            rigidbody.Sleep();
            reset = false;
        }
    }
}
