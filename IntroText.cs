using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroText : MonoBehaviour
{
    public int length;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
	{
        TW_MultiStrings_All txt;
        txt = gameObject.GetComponent<TW_MultiStrings_All>();
        txt.StartTypewriter();
		for (int i = 0; i < length; i++)
		{
            while (!Input.anyKeyDown)
            {
                yield return null;
            } 
            txt.NextString();
            Debug.Log("NEXT!");
           
            while (Input.anyKeyDown)
            {
                yield return null;
            }
        }
        while (!Input.anyKeyDown)
        {
            yield return null;
        }
        while (Input.anyKeyDown)
        {
            yield return null;
        }
        SceneManager.LoadScene(2);



    }

   
}
