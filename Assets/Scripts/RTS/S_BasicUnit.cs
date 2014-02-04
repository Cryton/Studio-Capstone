using UnityEngine;
using System.Collections;

public class S_BasicUnit : MonoBehaviour {
	public bool isSelected;
	Vector3 target;
	bool moving;
	public GameObject circle;
//	public CharacterController cont;
	// Use this for initialization
	void Start () 
	{
//		if(!cont)
//		{
//			transform.GetComponent<CharacterController>();	
//		}
	}
	
	// Update is called once per frame
	void Update () 
	{

		//print(cont.isGrounded);
		if(isSelected)
		{
			circle.renderer.enabled = true;
		}
		else
		{
			circle.renderer.enabled = false;
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
