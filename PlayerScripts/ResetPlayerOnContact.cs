using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerOnContact : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
	public void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.layer == 9)
        {
            gameObject.GetComponent<AudioManager>().PlaySound(2);
            gameObject.GetComponent<ResetToCheckPoint>().reset = true;
        }
	}
}
