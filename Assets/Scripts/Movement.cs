using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    float speed;
    float maxSpeed;
    float speedUPRate;
	// Use this for initialization
	void Start () {
        speed = 0f;
        maxSpeed = 5.0f;
        speedUPRate = 15.0f;
	}
	
	// Update is called once per frame
	void Update () {
        float h, v;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        Move(h,v);
	}

    void Move(float x,float y)
    {
        Vector2 pos;
        Vector2 target;
        MoveDirectionInput(x,y);
        pos = transform.position;
        target = pos+ new Vector2(x,y).normalized;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void MoveDirectionInput(float x, float y)
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            speed = SpeedUP(speed);
        }
        else
        {
            speed = 0f;
        }
    }

    float SpeedUP(float s)
    {
        if (s <= maxSpeed)
        {
            s += speedUPRate*Time.deltaTime ;
        }
        else
        {
            s = maxSpeed;
        }
        return s;
    }
}
