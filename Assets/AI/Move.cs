using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    string Camp = "";
    public bool is_Moving;
    public float Runspeed;
    public float Walkspeed;
    public float speed;
    float journey;
    float dist_covered;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (name != Camp)
        {
            Camp = name;
            is_Moving = true;
            speed = Walkspeed;
        }
        if (is_Moving)
        {
           
            //animation.Blend("Walking");
            Move_Now();
            
            
        }
	
	}

    void Move_Now()
    {
       
        if (Camp != null)
        {
            dist_covered = speed * Time.deltaTime;
            GameObject temp = GameObject.FindGameObjectWithTag("Camp_Site" + Camp);
            transform.LookAt(temp.transform);
            transform.position = Vector3.MoveTowards(transform.position, temp.transform.position, dist_covered);
            
            journey = Vector3.Distance(this.transform.position, temp.transform.position);

            if (journey < 40)
            {
                Stop();
            }


        }
    }
    public void Stop()
    {
        if (speed > 0)
        {
            speed -= Time.deltaTime;
        }
        else 
        is_Moving = false;

    }
}
