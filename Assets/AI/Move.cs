using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    string Camp = "";
    bool is_Moving;
    public float speed = 1;
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
            
        }
        if (is_Moving)
        {
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
                is_Moving = false;
            }


        }
    }
}
