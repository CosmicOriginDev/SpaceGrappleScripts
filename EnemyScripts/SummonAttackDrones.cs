using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAttackDrones : MonoBehaviour
{
	public GameObject AttackDrone;
	public float boundDistance;
	public float checkTime;
	void OnEnable()
	{
		StartCoroutine(Summon());
	}
	IEnumerator Summon()
	{
		while (true)
		{
			if (Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position) > boundDistance)
			{
				yield return new WaitForSecondsRealtime(checkTime);
				for (int i = 0; i < 2; i++)
				{
					Instantiate(AttackDrone, new Vector3(Random.Range(-10,10), Random.Range(-10, 10), Random.Range(-10, 10)),Quaternion.identity);
				}
			}
			else
			{
				
				GameObject[] drones = GameObject.FindGameObjectsWithTag("BorderDrone");
				if (drones != null)
				{
					foreach (GameObject drone in drones)
					{
						Destroy(drone);
					}
				}
				
				yield return null;
			}
		}
	}
		
}
