using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool gameIsPaused;
    public CameraOrbit Co;
    public Canvas PM;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
        if(gameIsPaused == false)
		{
            ResumeGame();
		}

    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        Co.enabled = false;
        PM.enabled = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        Co.enabled = true;
        PM.enabled = false;

    }
}
