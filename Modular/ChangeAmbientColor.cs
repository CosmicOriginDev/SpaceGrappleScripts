using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAmbientColor : MonoBehaviour
{
    public Color color;
    public void ChangeColor()
	{
        RenderSettings.ambientLight = color;
    }
}
