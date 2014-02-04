using UnityEngine;
using System.Collections;

public class Gooey : MonoBehaviour {

	Rect commandBox,unitBox,mapBox,escapeBox,mapBox2;
	float CBwidth, CBheight ,UBwidth, UBheight;
	int grid = 0;
	int escapegrid = 0;
	string[] selStrings, escapeString;
	public Texture2D image;
	public GUISkin skin, skin2;
	bool escape;
	public bool RTS;
	// Use this for initialization
	void Start () {
		escape = false;
		CBwidth = Screen.width/2;
		CBheight = Screen.height/4;
		UBwidth = Screen.width/4;
		UBheight = Screen.height/3.5f;
		commandBox = new Rect(Screen.width/2-CBwidth/2,Screen.height-CBheight,CBwidth,CBheight);
		unitBox = new Rect(Screen.width - UBwidth, Screen.height-UBheight,UBwidth,UBheight);
		mapBox = new Rect(0, Screen.height-UBheight,UBwidth,UBheight);
		mapBox2 = new Rect(Screen.width - Screen.width/40 - Screen.width/5 , 0 + Screen.height/30,Screen.width/5,Screen.height/4);
		escapeBox = new Rect(Screen.width/2-(Screen.width/10)/2 , Screen.height/2 -(Screen.height/5) ,Screen.width/10,Screen.height/5);
		selStrings = new string[] {"Attack!", "Defend", "Move Here", "Wait","Follow","Waypoint","Squad","Scatter"};
		escapeString = new string[] {"Return to Game","Settings","Return to Menu"};
	}
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape))
			escape = !escape;

		if(Input.GetKeyDown(KeyCode.C))
		{
			RTS = !RTS;
		}

		if(Input.GetKeyDown(KeyCode.B))
		{
			//RTS = !RTS;
			SwitchToFPS();
		}
	}

	void OnGUI()
	{
		if(RTS)
		{
			GUI.skin = skin;
			GUI.Box(commandBox,"Commands");
			grid = GUI.SelectionGrid(new Rect(commandBox.x + (commandBox.width - commandBox.width/2)/2, commandBox.y + (commandBox.height-commandBox.height/1.5f)/2 ,commandBox.width/2,commandBox.height/1.5f), grid, selStrings, 4);
			GUI.Box(unitBox,"Current Unit Image/Stats");
			GUI.Box(new Rect(unitBox.x + unitBox.width/20, unitBox.y + unitBox.height/10, unitBox.width*.4f, unitBox.height*.95f), image);
			GUI.Box(new Rect(unitBox.x + unitBox.width/20*2 + unitBox.width*.4f, unitBox.y + unitBox.height/10, unitBox.width*.5f, unitBox.height*.95f), "Unit Stats will go here" +"\r\n"+"\r\n"  + "Austin this week did RTS UI, Credits Video and different Options buttons" + "\r\n"+"\r\n"+ "Austin Next week is doing FPS UI/Button effects for a prettier UI"+"\r\n" +"\r\n" + "Goodbye Studio! PS. Don't trust Mr. Day" );
			GUI.Box(mapBox,"Map");
		}
		if(!RTS)
		{
			GUI.Box(mapBox2, "MAP");
			GUI.Button(new Rect(mapBox2.x + (mapBox2.width/3)*2, mapBox2.y + mapBox2.height + Screen.height/20 ,mapBox2.width/3 ,Screen.height/20), "Squad1");
			GUI.Button(new Rect(mapBox2.x + (mapBox2.width/3)*2, mapBox2.y + mapBox2.height + (Screen.height/20)*2 ,mapBox2.width/3 ,Screen.height/20), "Squad2");
			GUI.Button(new Rect(mapBox2.x + (mapBox2.width/3)*2, mapBox2.y + mapBox2.height + (Screen.height/20)*3 ,mapBox2.width/3 ,Screen.height/20), "Squad3");
			GUI.Button(new Rect(mapBox2.x + (mapBox2.width/3)*2, mapBox2.y + mapBox2.height + (Screen.height/20)*4 ,mapBox2.width/3 ,Screen.height/20), "Squad4");

			GUI.Button(new Rect(mapBox2.x + (mapBox2.width/3), mapBox2.y + mapBox2.height + (Screen.height/20)*6.5f ,mapBox2.width/3 ,mapBox2.width/3), "RTS");
			GUI.Box (new Rect(mapBox2.x , mapBox2.y + mapBox2.height + (Screen.height/20)*7 + mapBox2.width/3 ,mapBox2.width ,mapBox2.width), "Radar");
		}
		if(escape)
		{
			GUI.skin = skin2;
			GUI.Box(escapeBox,"Menu");
			escapegrid = GUI.SelectionGrid(new Rect(escapeBox.x + (escapeBox.width - escapeBox.width/1.2f)/2, escapeBox.y + (escapeBox.height-escapeBox.height/1.5f)/2 ,escapeBox.width/1.2f,escapeBox.height/1.5f), escapegrid, escapeString, 1);
			if (escapegrid == 2)
				Application.LoadLevel("Menu");
		}
	}
	public void SwitchToFPS()
	{
		S_Selector control = transform.parent.GetComponent<S_Selector>();
		control.Deselect();
		transform.parent.gameObject.SetActive(false);
	}
}
