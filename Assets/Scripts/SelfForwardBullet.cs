using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfForwardBullet : MonoBehaviour {
    Vector3 dir;
    public float speed;
	// Use this for initialization
	void Start () {
        dir = transform.right;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        Vector3 target;
        target = transform.position + dir;
        transform.position = Vector3.MoveTowards(transform.position,target,speed*Time.deltaTime);
    }
}
