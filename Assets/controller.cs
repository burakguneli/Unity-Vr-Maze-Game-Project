using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {

    private bool walking = false;
    private Vector3 spawnPoint;
    public bool seen = false;
    
   
     

	// Use this for initialization
	void Start () {
        
        walking = false;
        spawnPoint = transform.position;
        
        
	}
    
	
	// Update is called once per frame
	void Update () {
        if (walking)
        {
            transform.position = transform.position + Camera.main.transform.forward * .5f * Time.deltaTime;
        }

        if (transform.position.y < -10f) {
            transform.position = spawnPoint;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .9f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Contains("Quad"))
            {
                walking = true;
                seen = true;

            }
           
            if (hit.collider.name.Contains("Plane"))
            {
                walking = false;
            }
            else
            {
                if(seen)
                    {
                        walking = true;
                    }
            }
            if (hit.collider.CompareTag("Finish")){
                walking = false;
                transform.position = spawnPoint;
            }
           

        }
	}
}
