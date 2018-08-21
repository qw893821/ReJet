using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAction : MonoBehaviour {
    public GameObject[] drones;
    float rotateSpeed;
	// Use this for initialization
	void Start () {
        drones = GameObject.FindGameObjectsWithTag("Drone");
        rotateSpeed = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    private void FixedUpdate()
    {
        DroneMovement();
    }

    void DroneMovement()
    {
        Quaternion angle;
        angle = transform.rotation;
        angle *= Quaternion.Euler(new Vector3(0,0,rotateSpeed));
        transform.rotation = angle;
        foreach (GameObject go in drones)
        {
            Quaternion localangle;
            localangle = go.transform.rotation;
            localangle *= Quaternion.Euler(new Vector3(0,0,-rotateSpeed));
            go.transform.rotation = localangle;
        } 
    }

    
}
