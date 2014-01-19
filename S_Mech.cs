using UnityEngine;
using System.Collections;

public class S_Mech : MonoBehaviour {
	public GameObject torso,legs;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.A))
		{
			legs.transform.Rotate(Vector3.down);
		}
		if(Input.GetKey(KeyCode.D))
		{
			legs.transform.Rotate(Vector3.up);
		}
		torso.transform.Rotate(Vector3.up*Input.GetAxis("Mouse X"),Space.World);
		torso.transform.Rotate(Vector3.left*Input.GetAxis("Mouse Y"),Space.Self);
		//torso.transform.rotation.eulerAngles += new Vector3(Input.GetAxis("Mouse Y"),0,0);
		
	}
}
