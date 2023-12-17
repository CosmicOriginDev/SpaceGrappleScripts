using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleCounterRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(GameObject.Find("BlackHolePivot").GetComponent<BlackHoleRotate>().speed * -1 * Time.deltaTime, 0, 0);
    }
}
