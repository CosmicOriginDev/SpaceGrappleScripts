using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToScene : MonoBehaviour
{
    public int scene;
    public void ChangeScene()
	{
		SceneManager.LoadScene(scene);
	}

}
