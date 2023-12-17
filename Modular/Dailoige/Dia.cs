using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dia: MonoBehaviour
{
	private GameObject DiaBox;
	private Text Diatext;
	private Image DiaBG;
	private Text PETC;
	public int Ln;
	[TextArea]
	public string outTxt;
	public void Awake()
	{
		DiaBox = gameObject;
		Diatext = DiaBox.GetComponent<Text>();
		DiaBG = GameObject.Find("Canvas").transform.Find("HUD").transform.Find("BG").GetComponent<Image>();
		DiaBG.enabled = false;
		PETC = GameObject.Find("PETC").GetComponent<Text>();
		PETC.enabled = false;
		Ln = 0;
	}
	public void JumpToLine(int line)
	{
		Ln = line;
	}
	public void NextLine()
	{
		Ln=Ln+1;
	}
	public void DiaDisplay(string[] text)
	{
		DiaBG.enabled = true;
		outTxt = text[Ln];
		Diatext.text = outTxt;
		PETC.enabled = true;
	}
	public void Clear()
	{
		Diatext.text = " ";
		outTxt = "";
		DiaBG.enabled = false;
		PETC.enabled = false;
	}

	public void ShortDsip(string[] text)
	{
		DiaBG.enabled = true;
		outTxt = text[0];
		Diatext.text = outTxt;
		PETC.enabled = false;
		StartCoroutine(SpeakThenDelay(3f));
	}

	IEnumerator SpeakThenDelay(float seconds)
	{
		yield return new WaitForSecondsRealtime(seconds);
		Clear();
	}

}

