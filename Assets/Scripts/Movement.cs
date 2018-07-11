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
        if (transform.position.x <= -8.5 && x<0)
        {
            x = 0;
        }
        else if (transform.position.x >= 8.5 && x > 0)
        {
            x = 0;
        }
        if (transform.position.y < -4.5 &&y<0)
        {
            y = 0;
        }
        else if (transform.position.y > 4.5 && y > 0)
        {
            y = 0;
        }
        pos = transform.position;
        target = pos+ new Vector2(x,y).normalized;
        transform.position = Vector2.MoveTowards(transform.position, target, s * Time.deltaTime);
    }
}
