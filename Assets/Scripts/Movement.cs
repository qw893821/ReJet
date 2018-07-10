using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    float speed;
	// Use this for initialization
	void Start () {
        speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        float h, v;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        Move(h,v,speed);
	}

    void Move(float x,float y,float s)
    {
        Vector2 pos;
        Vector2 target;
        pos = transform.position;
        target = pos+ new Vector2(x,y).normalized;
        transform.position = Vector2.MoveTowards(transform.position, target, s * Time.deltaTime);
    }
}
