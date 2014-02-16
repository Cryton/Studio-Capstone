using UnityEngine;
using System.Collections;

public class Gooey : MonoBehaviour {

	public Camera MainCamera;
	Rect commandBox,unitBox,mapBox,escapeBox,mapBox2,settingsBox;
	float CBwidth, CBheight ,UBwidth, UBheight, renderDistance, volume;
	int AA;
	string resoW, resoY;
	int grid = 0;
	int escapegrid = 3;
	string[] selStrings, escapeString;
	public Texture2D image;
	public GUISkin skin, skin2;
	bool escape,settings, anisotropic,fullScreen;
	public bool RTS;
	// Use this for initialization
	void Start () {
		AA = 0;
		anisotropic = false;
		escape = false;
		fullScreen = true;
		renderDistance = 1000;
		resoW = "1920";
		resoY = "1080";
		Setup (int.Parse(resoW),int.Parse(resoY));
	}

	void Setup(int width, int height)
	{
		CBwidth = width/2;
		CBheight = height/4;
		UBwidth = width/4;
		UBheight = height/3.5f;
		commandBox = new Rect(width/2-CBwidth/2,height-CBheight,CBwidth,CBheight);
		unitBox = new Rect(width - UBwidth, height-UBheight,UBwidth,UBheight);
		mapBox = new Rect(0, height-UBheight,UBwidth,UBheight);
		mapBox2 = new Rect(width - width/40 - width/5 , 0 + height/30,width/5,height/4);
		escapeBox = new Rect(width/2-(width/10)/2 , height/2 -(height/5) ,width/10,height/5);
		settingsBox = new Rect(width/2-(width/1.5f)/2 , height/2 - (height/1.5f)/2 , width/1.5f, height/1.5f);
		selStrings = new string[] {"Attack!", "Defend", "Move Here", "Wait","Follow","Waypoint","Squad","Scatter"};
		escapeString = new string[] {"Return to Game","Settings","Return to Menu","PlaceHolder"};
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

			if(escapegrid == 0)
			{
				escape = false;
			}
			if(escapegrid == 1)
			{
				escape = false;
				settings = true;
			}
			else if (escapegrid == 2)
				Application.LoadLevel("Menu");
		}
		if(settings)
		{
			float offset = settingsBox.x/15;
			GUI.skin = skin2;
			GUI.Box(settingsBox, "Settings");
			AA =(int)GUI.HorizontalSlider(new Rect(settingsBox.x + offset ,settingsBox.y + offset ,settingsBox.x/3,settingsBox.y/10), AA,0f,3f);
			renderDistance = GUI.HorizontalSlider(new Rect(settingsBox.x + offset*40 ,settingsBox.y + offset ,settingsBox.x/3,settingsBox.y/10), renderDistance,1000f,2000f);
			anisotropic = GUI.Toggle(new Rect(settingsBox.x + offset*20,settingsBox.y + offset, settingsBox.x/1, settingsBox.y/5),anisotropic,"Anisotropic Filtering");
			fullScreen = GUI.Toggle(new Rect(settingsBox.x + offset*20,settingsBox.y + offset*5, settingsBox.x/1, settingsBox.y/5),fullScreen,"Fullscreen");
			resoW = GUI.TextField(new Rect(settingsBox.x + offset*20,settingsBox.y + offset*20, settingsBox.x/3, settingsBox.y/5),resoW);
			resoY = GUI.TextField(new Rect(settingsBox.x + offset*30,settingsBox.y + offset*20, settingsBox.x/3, settingsBox.y/5),resoY);
			volume = GUI.HorizontalSlider(new Rect(settingsBox.x + offset*40 ,settingsBox.y + offset*10 ,settingsBox.x/3,settingsBox.y/10), volume,0f,1f);

			Resolution[] resolutions = Screen.resolutions;
			int offsetAmount = 5;
			foreach(Resolution res in resolutions)
			{
				offsetAmount +=1;
				GUI.Label(new Rect(settingsBox.x + offset*25,settingsBox.y + offset*offsetAmount, settingsBox.x/1, settingsBox.y/5),res.width + "x" + res.height);
			}

			if(GUI.Button(new Rect(settingsBox.x + offset*10,settingsBox.y + offset, settingsBox.x/3, settingsBox.y/5), "Apply"))
			{
				AntiAliasing(AA);
				AnisotropicFilter(anisotropic);
				Maximize(fullScreen);
				ViewDistance(renderDistance);
				Setup (int.Parse(resoW),int.Parse(resoY));
				ResolutionChange(resoW, resoY);
			}
			if(GUI.Button(new Rect(settingsBox.x + offset,settingsBox.y + offset*20, settingsBox.x/5, settingsBox.y/5), "Menu"))
			{
				settings = false;
				escape = true;
				escapegrid = 3;
			}
			if(GUI.Button(new Rect(settingsBox.x + offset,settingsBox.y + offset*10, settingsBox.x/5, settingsBox.y/5), "Audio Test"))
			{
				MainCamera.audio.Play();
			}
			MainCamera.audio.volume = volume;
		}
	}
	public void ResolutionChange(string w, string y)
	{
		int width = int.Parse(w);
		int height = int.Parse(y);
		Screen.SetResolution(width,height, fullScreen);
	}
	public void Maximize(bool full)
	{
		if(full)
			Screen.fullScreen = true;
		else
			Screen.fullScreen = false;
	}

	public void ViewDistance(float render)
	{
		MainCamera.farClipPlane = render;
	}

	public void AnisotropicFilter(bool boo)
			{
				if (!boo)
				QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
				else
					QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
			}

	public void AntiAliasing(int amount)
	{
		amount*=2;
		if(amount == 6)
			amount =8;
		QualitySettings.antiAliasing = amount;
	}

	public void SwitchToFPS()
	{
		S_Selector control = transform.parent.GetComponent<S_Selector>();
		control.Deselect();
		transform.parent.gameObject.SetActive(false);
	}
}
