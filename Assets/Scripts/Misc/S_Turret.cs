using UnityEngine;
using System.Collections;

public class S_Turret : MonoBehaviour {
	public Transform target,turret1,turret2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		turret1.LookAt(target.transform.position);
		turret1.transform.Rotate(new Vector3(-90,0,0));
	}
}
