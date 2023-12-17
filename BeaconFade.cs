using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconFade : MonoBehaviour
{
    public ParticleSystem BeaconPartical;
    public GameObject BeaconObject;
    public Vector3 ScreenCoords;
    public Camera Camera;
    public GameObject Player;
    public float distance;
    public float playerDistance;
    public float threshold;
    public float playerThreshold;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //find coords on screen
        ScreenCoords = Camera.WorldToScreenPoint(gameObject.transform.position);
        //Get distance to cursor
        distance = Mathf.Sqrt(Mathf.Pow((Screen.width / 2 - ScreenCoords.x),2) - Mathf.Pow((Screen.height / 2 - ScreenCoords.y),2));
        playerDistance = Vector3.Distance(Player.transform.position, gameObject.transform.position);
        if (playerDistance < playerThreshold)
        {
            if (distance < threshold)
            {
                var BoldColor = BeaconPartical.main;
                BoldColor.startColor = new ParticleSystem.MinMaxGradient(new Color(1f, 1f, 1f, 0.75f));
            }
            else
            {
                var FadeColor = BeaconPartical.main;
                FadeColor.startColor = new ParticleSystem.MinMaxGradient(new Color(1f, 1f, 1f, 0.4f));
            }
        }
        else
		{
            var NoColor = BeaconPartical.main;
            NoColor.startColor = new ParticleSystem.MinMaxGradient(new Color(1f, 1f, 1f, 0f));
        }
    }


    

}
