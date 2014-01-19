using UnityEngine;
using System.Collections;

public class S : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float ang = Vector3.Angle(target.position-transform.position,-transform.right);
		float ang2 = Vector3.Angle(target.position-transform.position,transform.right);
		float ang3 = Vector3.Angle(target.position-transform.position,transform.forward);
		float vertAng = Vector3.Angle(target.position-transform.position,transform.up);
		print(vertAng);
		if(ang3 > 2)
		{
			if(ang < ang2)
			{
				transform.Rotate(-transform.up);
			}
			else
			{
				transform.Rotate(transform.up);
			}
			
		}
		if(vertAng > 2)
		{
			
		}
		
	}
}
