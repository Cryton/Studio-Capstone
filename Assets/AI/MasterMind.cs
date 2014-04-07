using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterMind : MonoBehaviour {
    public GameObject soldier;
    public GameObject spawn;
    public List<GameObject> Waypoints = new List<GameObject>(); 
     List<ArrayList> camps ;
    //List <GameObject> peeps = new List<GameObject>();
    public float timer;
    int tracker = 0;
    GameObject temp;
    
     
	// Use this for initialization
	void Start () {
        camps = new List<ArrayList>(Waypoints.Count);
        
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= 10)
        {
            
           temp = (Instantiate(soldier, spawn.transform.position,spawn.transform.rotation)) as GameObject;
            
           timer = 0;
           
           if (tracker > Waypoints.Count-1)
           {
               tracker = 0;
           }
           //MoveSoldier(tracker, temp);
           Ask();
            
           tracker++;
        }

       
	
	}
    //Add the soldier to a camp
    /*void MoveSoldier(int spot, GameObject gObject)
    {
        //tracker = spot;
    
        gObject.name = spot.ToString();
        //peeps.Add(gObject);
        Ask();
        
            
        

    }*/
    //Ask for soldiers
    void Ask()
    {
        GameObject[] player;
        player = GameObject.FindGameObjectsWithTag("PlayerUnit");
        Vector3 adv= new Vector3();
        int total = 0;
        float dist = 0;
        foreach (GameObject p in player)
        {
            adv += p.transform.position;
            total++;
        }
        adv.x = adv.x / total;
        adv.y = adv.y / total;
        adv.z = adv.z / total;
        //dist = the first Waypoint
        dist = Vector3.Distance(Waypoints[0].transform.position, adv);
        int follow=0, pos_w=0;
        foreach (GameObject w in Waypoints)
        {
            if (dist >= (Vector3.Distance( w.transform.position,adv)))
            {
                dist = (Vector3.Distance( w.transform.position, adv));
                pos_w = follow;
            }
            follow++;
        }
        if (dist < 40f)
        {
            MoveCamps(pos_w, Waypoints[pos_w].transform.position );
        }
        else
        {
            MoveCamps(tracker, Waypoints[tracker].transform.position);

        }


    }

    //Moves current enemys to a camp
    void MoveCamps(int campnumber,Vector3 point)
    {
        GameObject[] GetEnemy;
        GetEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        //player = GameObject.FindGameObjectsWithTag((campnumber - 1).ToString());
        foreach (GameObject g in GetEnemy)
        {
            if (g != null)
            {
                g.SendMessage("Move", point);
            }
        }
        /*if (Waypoints[campnumber + 1] != null)
        {
            foreach (GameObject s in peeps)
            {
                if (s.name == (campnumber + 1).ToString())
                {
                    s.name = campnumber.ToString();
                }
            }
        }

        else if (Waypoints[campnumber - 1] != null)
        {
            foreach (GameObject s in peeps)
            {
                if (s.name == (campnumber - 1).ToString())
                {
                    s.name = campnumber.ToString();
                }
            }
        }*/

    }
    


}
