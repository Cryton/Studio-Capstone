using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    public GameObject factory;
    bool spawnBuilding = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            spawnBuilding = true;
        }

        if (spawnBuilding == true)
        {
            RaycastHit hit;
            		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            		if (Physics.Raycast(ray, out hit,100))
            			{
            				print ("pew");
            				if (hit.transform.tag == "Terrain")
                                Instantiate(factory.transform.TransformPoint(hit.point));
                            spawnBuilding = false;
            			}
        }
	
	}
}
