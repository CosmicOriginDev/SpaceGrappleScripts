using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaySomething))]
public class FileScanScript : MonoBehaviour
{
    public string FilesFound;
    public string Name;
    public string Date;
    public string Owner;
    private SaySomething SaySomething;
    [TextArea]
    private string[] text;
    private string[] mod;
    private List<string> output;
    // Start is called before the first frame update
    void Start()
    {
        SaySomething = gameObject.GetComponent<SaySomething>();
        text = SaySomething.DiaLog;
        mod = new string[]{"scanning system hard disk...", FilesFound + " uncorrupted file found.","attempting to translate alien message...","translation successful!","<color=lime>File Metadata:</color>" + "\nname: " + Name + "\ndate: " + Date + "\nowner: " + Owner};
        output = new List<string>();
		foreach (string item in mod)
		{
            output.Add(item);
        }
        foreach (string item in text)
        {
            output.Add(item);
        }
        output.Add("end of file");

        SaySomething.DiaLog = output.ToArray();
    }


}
