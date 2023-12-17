using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioMixerSnapshot[] snapshot;
	public float speed;
    public void ChangeTrack(int num)
	{
		Debug.Log("SWITCHED TRACK TO " + num);
		snapshot[num].TransitionTo(speed);
	}
}
