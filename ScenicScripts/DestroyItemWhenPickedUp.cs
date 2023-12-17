using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItemWhenPickedUp : MonoBehaviour
{
    private bool e;
    // Start is called before the first frame update
    void Start()
    {
        e = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<StoreUpgrades>().Grenades == true && e == false)
        {
            e = true;
            Destroy(gameObject);
        }
    }
}
