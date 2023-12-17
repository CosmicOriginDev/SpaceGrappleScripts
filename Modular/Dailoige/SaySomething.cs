using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaySomething : MonoBehaviour
{
	[TextArea]
	public string[] DiaLog;
	private GameObject Msys;
	private Dia Dia;
	public bool WaitUntilDone;
	public bool shortSpeak;
	private void Start()
	{
		Msys = GameObject.Find("MessageSystem");
		Dia = Msys.GetComponent<Dia>();
		WaitUntilDone = false;
	}
	// Start is called before the first frame update
	public void Speak()
	{
		if (WaitUntilDone == false)
		{
			Debug.Log("SPEAK!");
			WaitUntilDone = true;
			StartCoroutine(SpeakIE());

		}
		
	}
	public IEnumerator SpeakIE()
	{
		if (shortSpeak == false)
		{
			Debug.Log("SPEAKING!");
			//Dia.JumpToLine(0);
			for (int i = 0; i < DiaLog.Length; i++)
			{
				Debug.Log("SPEAKING LINE " + i);
				Dia.JumpToLine(i);
				Dia.DiaDisplay(DiaLog);
				while (Input.GetKeyDown(KeyCode.Return))
				{
					yield return null;
				}
				while (Input.GetKeyDown(KeyCode.Return) == false)
				{
					yield return null;
				}

			}
			Dia.Clear();
			WaitUntilDone = false;
			yield break;
		}
		else
		{
			Dia.ShortDsip(DiaLog);
		}
		
	}
}
