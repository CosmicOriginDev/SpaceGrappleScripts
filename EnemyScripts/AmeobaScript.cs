using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AmeobaScript : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;
    private Collider collider;
    public float speed;
    public float ghostMult;
    public bool risen;
    public float riseThresh;
    public float riseHeight;
    public float teleportDistance;
    public float RushDistance;
    public bool Ghostmode;
    private Animation Anim;
    public float snapDist;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody>();
        collider = gameObject.GetComponent<Collider>();
        Anim = gameObject.transform.Find("SnakeMonsterHead").transform.Find("Cylinder").GetComponent<Animation>();
        
    }
	void Awake()
	{


    }

	// Update is called once per frame
	void Update()
    {
        if (Mathf.Abs(player.transform.position.y - gameObject.transform.position.y+riseHeight) > riseThresh && risen == false)
        {
            rb.AddForce(new Vector3(0, (player.transform.position.y + riseHeight - gameObject.transform.position.y ) * speed, 0), ForceMode.Force);
        }
        else
        {
            risen = true;
            gameObject.transform.LookAt(player.GetComponent<Transform>());
            //rb.AddForce((player.transform.position - gameObject.transform.position) * speed, ForceMode.Force);
            if (Vector3.Distance(gameObject.transform.position,player.transform.position) > teleportDistance)
			{
                Ghostmode = true;
                
            }
            else
			{
                Ghostmode = false;
              

            }
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) > RushDistance)
            {
                rb.AddForce(transform.forward * speed * 10 * ghostMult);
            }
            else
            {
                rb.AddForce(transform.forward * speed * 10);

            }


        }
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < snapDist)
        {
            Anim.Play();
        }
        else
        {
            Anim.Stop();
        }







    }

	


    
    
    

}
