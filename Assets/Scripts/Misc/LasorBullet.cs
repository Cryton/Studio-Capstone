using UnityEngine;
using System.Collections;

public class LasorBullet : MonoBehaviour {
	public float life;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.forward);
		life++;
		if(life > 30)
		{
			Destroy(gameObject);
		}
	}
}
