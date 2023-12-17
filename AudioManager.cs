using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioClip[] Sounds;
	private AudioSource Source;

	private void Start()
	{
		Source = gameObject.GetComponent<AudioSource>();
	}
	public void PlaySound(int id)
	{
		Source.clip = Sounds[id];
		if (Source.isPlaying == false)
		{
			Source.Play();
		}
	}
}
