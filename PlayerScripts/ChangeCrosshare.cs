using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCrosshare : MonoBehaviour
{
    public bool BoolPink;
    private Image crosshareimage;
    public Sprite grey;
    public Sprite pink;
    // Start is called before the first frame update
    void Start()
    {
        crosshareimage = GameObject.Find("Canvas").transform.Find("HUD").transform.Find("Crosshare").GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(BoolPink)
		{
            crosshareimage.sprite = pink;
		}
        else
		{
            crosshareimage.sprite = grey;
        }
    }
}
