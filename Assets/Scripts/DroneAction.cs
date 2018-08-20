using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAction : MonoBehaviour {
    GameObject[] drones;
    float time;
	// Use this for initialization
	void Start () {
        drones = GameObject.FindGameObjectsWithTag("Drone");
	}
	
	// Update is called once per frame
	void Update () {
        DroneMovement();
	}

    void DroneMovement()
    {
        time += Time.deltaTime;
        float radius = 1f;
        float angle = 360.0f / drones.Length;
        for(int i = 0; i < drones.Length; i++)
        {
            if (i == 0)
            {
                Vector3 pos;
                pos = new Vector3(Mathf.Sin(time),Mathf.Cos(time),0f);
                drones[0].transform.localPosition =pos;
                Debug.Log(drones[0].transform.position);
            }
            else
            {
                //Vector3 pos;
                //pos = transform.position - transform.parent.position;
                //pos.
                //drones[i].
                
            }
        }
    }
}
