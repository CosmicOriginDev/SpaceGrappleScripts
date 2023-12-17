using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableProjection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CharacterJoint>().enableProjection = true;
    }


}
