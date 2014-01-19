using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_Selector : MonoBehaviour {
	public Vector3 start, finish,mouseStart,boxVect;
	public List<GameObject> selectedUnits;
	bool dragBox;
	public GameObject b1,b2;
	//This assumes 0,0 to be in bottom left**
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetMouseButtonDown(0))
		{
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(r,out hit,100))
			{
				start = hit.point;
				mouseStart = Input.mousePosition;
				dragBox = true;
				//b1.transform.position = start;
			}
		}
		if(Input.GetMouseButtonUp(0))
		{
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(r,out hit,100))
			{
				finish = hit.point;
				//b2.transform.position = finish;
				if(hit.transform.gameObject.tag == "PlayerUnit")
				{
					SelectionBox(hit.transform.gameObject);
				}
				else
				{
					SelectionBox(null);
				}
				//SelectionBox();
				dragBox = false;
			}
		}
		if(Input.GetMouseButton(1))
		{
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(r,out hit,100))
			{
				foreach(GameObject g in selectedUnits)
				{
					S_BasicUnit unit = g.GetComponent<S_BasicUnit>();
					unit.Move(hit.point);
				}
			}
		}
		
	}
	void SelectionBox(GameObject g)
	{
		foreach(GameObject uni in selectedUnits)
		{
			S_BasicUnit unit = uni.GetComponent<S_BasicUnit>();
			unit.isSelected = false;
		}
		selectedUnits.Clear();
		if(g)
		{
			selectedUnits.Add(g);
		}
		int boxType; //1=bottomleft-topright  2=topleft-bottomright 3 =bottomright-topleft 4= topright-bottomleft
		if(start.x > finish.x)
		{
			if(start.z > finish.z)
			{
				boxType = 4;
				GameObject[] pool = GameObject.FindGameObjectsWithTag("PlayerUnit");
				foreach(GameObject unit in pool)
				{
					if((unit.transform.position.x > finish.x && unit.transform.position.x < start.x) && (unit.transform.position.z > finish.z && unit.transform.position.z < start.z))
					{
						selectedUnits.Add(unit);
					}
				}
			}
			else
			{
				boxType = 3;
				GameObject[] pool = GameObject.FindGameObjectsWithTag("PlayerUnit");
				foreach(GameObject unit in pool)
				{
					if((unit.transform.position.x > finish.x && unit.transform.position.x < start.x) && (unit.transform.position.z > start.z && unit.transform.position.z < finish.z))
					{
						selectedUnits.Add(unit);
					}
				}
			}
		}
		else
		{
			if(start.z > finish.z)
			{
				boxType = 2;
				GameObject[] pool = GameObject.FindGameObjectsWithTag("PlayerUnit");
				foreach(GameObject unit in pool)
				{
					if((unit.transform.position.x > start.x && unit.transform.position.x < finish.x) && (unit.transform.position.z > finish.z && unit.transform.position.z < start.z))
					{
						selectedUnits.Add(unit);
					}
				}
			}
			else
			{
				boxType = 1;
				GameObject[] pool = GameObject.FindGameObjectsWithTag("PlayerUnit");
				foreach(GameObject unit in pool)
				{
					if((unit.transform.position.x > start.x && unit.transform.position.x < finish.x) && (unit.transform.position.z > start.z && unit.transform.position.z < finish.z))
					{
						selectedUnits.Add(unit);
					}
				}
				
			}
			
		}
		foreach(GameObject uni in selectedUnits)
		{
			S_BasicUnit unit = uni.GetComponent<S_BasicUnit>();
			unit.isSelected = true;
		}
		
		
	}
	
	void OnGUI()
	{
		//GUI.Box(new Rect(boxVect.x,boxVect.y,40,40),"Hello");
		//print(Input.mousePosition);
		if(dragBox)
		{
			Vector3 mouse = Input.mousePosition;
			if(mouse.x > mouseStart.x)
			{
				if(mouse.y > mouseStart.y)
				{
					GUI.Box(new Rect(mouseStart.x,(Screen.height - mouse.y),mouse.x-mouseStart.x,mouse.y-mouseStart.y),"");
				}
				else
				{
					GUI.Box(new Rect(mouseStart.x,(Screen.height - mouseStart.y),mouse.x-mouseStart.x,mouseStart.y-mouse.y),"");
				}
			}
			else
			{
				if(mouse.y > mouseStart.y)
				{
					GUI.Box(new Rect(mouse.x,(Screen.height - mouse.y),mouseStart.x-mouse.x,mouse.y-mouseStart.y),"");
				}
				else
				{
					GUI.Box(new Rect(mouse.x,(Screen.height - mouseStart.y),mouseStart.x-mouse.x,mouseStart.y-mouse.y),"");
				}
			}
			
		}
	}
}
