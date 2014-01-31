using UnityEngine;
using System.Collections;

public class S_BasicUnit : MonoBehaviour {
	public bool isSelected;
	Vector3 target;
	bool moving;
	public CharacterController cont;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!cont)
		{
			transform.GetComponent<CharacterController>();	
		}
		//print(cont.isGrounded);
		if(isSelected)
		{
			renderer.material.color = new Color(0,100,0,100);	
		}
		else
		{
			renderer.material.color = new Color(100,0,0,100);
		}
//		if(moving)
//		{
//			transform.LookAt(target);
//			transform.rotation = new Quaternion(0,transform.rotation.y,0,transform.rotation.w);
//			cont.SimpleMove(transform.forward);
//			//transform.Translate(Vector3.forward*.25f);
//			if(Vector3.Distance(transform.position,target) < 1)
//			{
//				moving = false;	
//			}
//		}
	}
	public void Move(Vector3 point)
	{
		AIPath pathing = transform.GetComponent<AIPath>();
		pathing.target = point;
	}
}
