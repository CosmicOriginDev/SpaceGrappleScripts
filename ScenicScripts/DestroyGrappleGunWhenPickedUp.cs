using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGrappleGunWhenPickedUp : MonoBehaviour
{
    public AudioSource MusicTrack;
    public AudioLowPassFilter LowPassFilter;
    public AudioSource Transition;
    public GameObject HiddenGrappleCube;
    public GameObject HiddenReleaseMessage;
    private bool e;
    // Start is called before the first frame update
    void Start()
    {
        e = false;
        HiddenGrappleCube.active = false;
        HiddenReleaseMessage.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<StoreUpgrades>().GrappleGun == true && e == false)
		{
            StartCoroutine(TransitionToMain());
            e = true;
        }
    }
    IEnumerator TransitionToMain()
	{
        yield return null;
        gameObject.GetComponent<MeshRenderer>().enabled = false; //Make Gun Invisible
        MusicTrack.mute = true; //Mute Music
        Transition.Play(); //Play Transition to go from Low Pass to no Low Pass
        yield return new WaitForSecondsRealtime(1f); //Wait until transition is done
        MusicTrack.mute = false; // Unmute Music
        LowPassFilter.enabled = false; //Disable LowPass
        MusicTrack.spatialBlend = 0; //Make Music 2D so it is like background music
        HiddenGrappleCube.active = true;
        HiddenReleaseMessage.active = true;
        Destroy(gameObject);

    }




}
