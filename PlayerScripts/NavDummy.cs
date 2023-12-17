using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavDummy : MonoBehaviour
{
    private GameObject Player;
    private GameObject MC;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        MC = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Player.transform.position;
        gameObject.transform.LookAt(MC.transform, new Vector3(1,0,0));
    }
}
