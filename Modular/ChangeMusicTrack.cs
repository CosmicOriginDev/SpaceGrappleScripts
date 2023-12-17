using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ChangeMusicTrack : MonoBehaviour
{
	public MusicManager MusicManager;
	public int track;
	public void Change()
	{
		MusicManager.ChangeTrack(track);
		
	}
}
