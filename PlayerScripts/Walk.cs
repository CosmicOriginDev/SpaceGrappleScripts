using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;
    private CharacterController groundcol;
    public bool grounded;
    public float speed;
    public float maxVelocityChange;
    public float jump;
    public float haxis;
    public float vaxis;
    public bool jumpInput;
    public float maxslope;
    public float tumbleTime;
    public float steep;
    public float redX, redZ;
    public bool freezeVector;
    public bool onhill;
    public bool CamAligned;
    private GameObject SpaceLegs;
    private GameObject WalkLegs;
    private Animation anim;
    public PhysicMaterial bounce;
    public PhysicMaterial friction;
    private GameObject EvSys;
    private GameObject MC;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        col = gameObject.GetComponent<SphereCollider>();
        SpaceLegs = transform.Find("RagdollLegs").gameObject;
        WalkLegs = transform.Find("AnimatedLegs").gameObject;
        anim = WalkLegs.GetComponent<Animation>();
        EvSys = GameObject.Find("EventSystem");
        MC = GameObject.Find("Main Camera");
    }

	// Update is called once per frame
	void Update()
	{
        haxis = Input.GetAxis("Horizontal");
        vaxis = Input.GetAxis("Vertical");
        jumpInput = Input.GetKey(KeyCode.Space);
        //Toggle Legs
        if(grounded == true)
		{
            SpaceLegs.SetActive(false);
            WalkLegs.SetActive(true);
            if (vaxis > 0)
            {
                anim.Play();
            }
            else
			{
                anim.Stop();
			}
        }
        else
		{
            SpaceLegs.SetActive(true);
            WalkLegs.SetActive(false);
        }
        grounded = Physics.Raycast(transform.position + new Vector3(0, -1, 0), new Vector3(0, -1, 0), 1);
    }
    void FixedUpdate()
    {
        if (grounded && EvSys.GetComponent<Gravity>().grav < 0)
        {
            rb.freezeRotation = true;
            //rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
            Quaternion currentrot = gameObject.transform.rotation;
            Quaternion newrot = Quaternion.AngleAxis(MC.GetComponent<CameraOrbit>().rotationYAxis, Vector3.up);

            //rb.freezeRotation = true;
            rb.drag = 1;
            Vector3 targetVelocity = new Vector3(haxis, 0, vaxis);
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;

            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            //Slerp until camera is aligned
            if (currentrot != newrot && CamAligned == false)
            {
                rb.rotation = Quaternion.Slerp(currentrot, newrot, 0.1f);
                if (Quaternion.Angle(rb.rotation, newrot) <= 1)
                {
                    CamAligned = true;
                }
            }
            if (CamAligned == true)
            {
                rb.rotation = newrot;
            }


            //steep = GetSlope(new Vector3(rb.velocity.normalized.x, 0, rb.velocity.normalized.z));
            //Debug.Log(steep);

            rb.AddForce(new Vector3(velocityChange.x, velocityChange.y, velocityChange.z), ForceMode.VelocityChange);
            if (jumpInput && grounded == true)
            {

                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
                //grounded = false;
            }
            /*
            if (steep > 0 && steep < 90)

            {
                onhill = true;
            }
            if (steep <= 0 && onhill == true)
            {



                Debug.Log("Hi");
                onhill = false;
            }
            */
        }
        else
        {
            //rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rb.freezeRotation = false;
            rb.drag = 0;
            CamAligned = false;
        }
    }

	/*private void OnCollisionStay(Collision collision)
	{
        grounded = true;
        
	}

	private void OnCollisionExit(Collision collision)
	{
        grounded = false;
	}
    */
	public float GetSlope(Vector3 direction)
	{
		// Have two rays on top of each other compare differance in distance
		// to calculate the slope

		// Assign rays
		RaycastHit[] topHit;
		RaycastHit[] bottomHit;
        topHit = Physics.RaycastAll(gameObject.transform.position + new Vector3(0, -0.8f, 0), new Vector3(direction.x,0,direction.z), 4f);
        bottomHit = Physics.RaycastAll(gameObject.transform.position + new Vector3(0, -0.9f, 0), new Vector3(direction.x,0,direction.z), 4f);
        //Ray topRay = new Ray(gameObject.transform.position + new Vector3(0, 0.1f, 0), new Vector3(0, yaw, 0));
        //Ray bottomRay = new Ray(gameObject.transform.position + new Vector3(0, -0.1f, 0), new Vector3(0, yaw, 0));
        // Cast rays
        RaycastHit truetop;
        RaycastHit truebottom;
        float td, bd;
        td = Mathf.Infinity;
        bd = 0;
        foreach(RaycastHit th in topHit)
	    {
            if(th.collider != gameObject)
			{
                truetop = th;
                td = truetop.distance;
                break;
			}
		}
        foreach (RaycastHit th in bottomHit)
        {
            if (th.collider != gameObject)
            {
                truebottom = th;
                bd = truebottom.distance;
                break;
            }
            
        }
        float dif = td - bd;
		// Calculate Slope
		float angle = Mathf.Atan(0.1f / dif) * Mathf.Rad2Deg;
		return angle;
		

	}

	


}
