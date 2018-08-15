using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSensor : MonoBehaviour {
    public GameObject parentMine;
    LineRenderer lr;
	// Use this for initialization
	void Start () {
        lr = transform.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            parentMine.SendMessage("React");
            lr.enabled = false;
        }
    }
}
