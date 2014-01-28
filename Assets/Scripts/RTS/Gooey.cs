using UnityEngine;
using System.Collections;

public class Gooey : MonoBehaviour {

	Rect commandBox,unitBox,mapBox;
	float CBwidth, CBheight ,UBwidth, UBheight;
	// Use this for initialization
	void Start () {
		CBwidth = Screen.width/2;
		CBheight = Screen.height/4;
		UBwidth = Screen.width/4;
		UBheight = Screen.height/3.5f;
		commandBox = new Rect(Screen.width/2-CBwidth/2,Screen.height-CBheight,CBwidth,CBheight);
		unitBox = new Rect(Screen.width - UBwidth, Screen.height-UBheight,UBwidth,UBheight);
		mapBox = new Rect(0, Screen.height-UBheight,UBwidth,UBheight);
	}
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Box(commandBox,"Test");
		GUI.Box(unitBox,"Test");
		GUI.Box(mapBox,"Test");
	}
}
