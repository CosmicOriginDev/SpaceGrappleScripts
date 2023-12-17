using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerWhenInteracted : MonoBehaviour
{
    private RaycastHit hit;
    public UnityEvent Output;
    public bool PreventSpam;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Physics.Raycast(GameObject.Find("Player").GetComponent<InteractWithE>().ray, out hit))
            {
                if (PreventSpam == false)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        Debug.Log("TRIGGERED!");
                        Output.Invoke();
                        PreventSpam = true;
                    }
                }
                else
		    	{
                    if (hit.collider.gameObject != gameObject)
                    {
                        PreventSpam = false;
                    }
                }
            }
            if(Input.GetKeyUp(KeyCode.E))
		    {
                PreventSpam = false;
		    }
        
       
           
            
    }
}
