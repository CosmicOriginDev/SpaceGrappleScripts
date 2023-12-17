using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    public float speed;
    public float range;
    public bool HitSomthing;
    public float manuverSpeed;
    public Camera camera;
    public SpringJoint grapple;
    public Rigidbody rigidbody;
    public GameObject player;
    public RaycastHit hit;
    public float kickForce;
    public float grapDist;
    public GameObject gun;
    private AudioManager Audio;
    private LineRenderer Laser;
    private GameObject GunBeamCenter;
    private ChangeCrosshare CC;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        grapple = player.GetComponent<SpringJoint>();
        rigidbody = player.GetComponent<Rigidbody>();
        gun = GameObject.Find("GunAntiDistort");
        Audio = player.GetComponent<AudioManager>();
        Laser = gun.GetComponent<LineRenderer>();
        Laser.startWidth = 0;
        Laser.endWidth = 0;
        GunBeamCenter = GameObject.Find("GunBeamCenter");
        CC = player.GetComponent<ChangeCrosshare>();
    }

    // Update is called once per frame
    void Update()
    {
     
        Laser.SetPosition(0, GunBeamCenter.transform.position);
       
        Ray ray = camera.ScreenPointToRay(screenCenter()); 
        if(grapple.connectedBody != null)
		{
            Laser.SetPosition(1, grapple.connectedBody.gameObject.transform.position);

        }
        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.gameObject.layer != 8 && hit.collider.gameObject.layer != 9 && hit.collider.gameObject.layer != 13 && hit.collider.gameObject.layer != 14)
            {
                HitSomthing = true;

                Transform objectHit = hit.transform;
            }
        }
        else
		{
            HitSomthing = false;
		}
        if(HitSomthing)
		{
            CC.BoolPink = true;
		}
        else
		{
            CC.BoolPink = false;
		}
        if(Input.GetMouseButton(1))
		{
            
            BreakGrapple();
        }
        if(Input.GetMouseButton(0))
		{

            if (HitSomthing == true)
			{
                MakeGrapple();

            }

        }
        
        if(Input.GetMouseButtonUp(0))
		{
            grapDist = manuverSpeed-(manuverSpeed/Vector3.Distance(player.transform.position, grapple.connectedBody.transform.position));
            grapple.spring = grapDist;
		}
        
        
        //Check if grapple is disabled
        if(player.GetComponent<DisableGrapple>().GrappleEnabled == false)
		{
            BreakGrapple();
		}
    }
    

    public void MakeGrapple()
	{
        if (hit.collider.gameObject.layer != 8 && hit.collider.gameObject.layer != 9 && hit.collider.gameObject.layer != 13 && hit.collider.gameObject.layer != 14)
        {
            Audio.PlaySound(0);
            grapple.connectedBody = hit.rigidbody;
            grapple.anchor = Vector3.zero;
            Laser.SetPosition(1, hit.rigidbody.transform.position);
            Laser.startWidth = 0.1f;
            Laser.endWidth = 0.1f;
            grapple.spring = speed;
        }
        else
        {
            HitSomthing = false;
        }

    }

    public void BreakGrapple()
	{
        Audio.PlaySound(1);
        grapple.spring = 0;
        grapple.connectedBody = null;
        Laser.startWidth = 0;
        Laser.endWidth = 0;
    }
    public void BreakGrappleNoSound()
    {
        grapple.spring = 0;
        grapple.connectedBody = null;
        Laser.startWidth = 0;
        Laser.endWidth = 0;
    }

    public Vector3 screenCenter()
	{
        return (new Vector3(Screen.width / 2, Screen.height / 2,0));
	}

    
}
