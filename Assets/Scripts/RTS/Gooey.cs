using UnityEngine;
using System.Collections;

public class Gooey : MonoBehaviour {

	Rect commandBox,unitBox,mapBox;
	float CBwidth, CBheight ,UBwidth, UBheight;
	int grid = 0;
	string[] selStrings;
	public Texture2D image;
	public GUISkin skin;
	// Use this for initialization
	void Start () {
		CBwidth = Screen.width/2;
		CBheight = Screen.height/4;
		UBwidth = Screen.width/4;
		UBheight = Screen.height/3.5f;
		commandBox = new Rect(Screen.width/2-CBwidth/2,Screen.height-CBheight,CBwidth,CBheight);
		unitBox = new Rect(Screen.width - UBwidth, Screen.height-UBheight,UBwidth,UBheight);
		mapBox = new Rect(0, Screen.height-UBheight,UBwidth,UBheight);
		selStrings = new string[] {"Attack!", "Defend", "Move Here", "Wait","Follow","Waypoint","Squad","Scatter"};
	}
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Box(commandBox,"Commands");
		grid = GUI.SelectionGrid(new Rect(commandBox.x + (commandBox.width - commandBox.width/2)/2, commandBox.y + (commandBox.height-commandBox.height/1.5f)/2 ,commandBox.width/2,commandBox.height/1.5f), grid, selStrings, 4);
		GUI.Box(unitBox,"Current Unit Image/Stats");
		GUI.Box(new Rect(unitBox.x + unitBox.width/20, unitBox.y + unitBox.height/10, unitBox.width*.4f, unitBox.height*.95f), image);
		GUI.Box(new Rect(unitBox.x + unitBox.width/20*2 + unitBox.width*.4f, unitBox.y + unitBox.height/10, unitBox.width*.5f, unitBox.height*.95f), "Unit Stats will go here" +"\r\n"+"\r\n"  + "Austin this week did RTS UI, Credits Video and different Options buttons" + "\r\n"+"\r\n"+ "Austin Next week is doing FPS UI/Button effects for a prettier UI"+"\r\n" +"\r\n" + "Goodbye Studio! PS. Don't trust Mr. Day" );
		GUI.Box(mapBox,"Map");
	}
}
