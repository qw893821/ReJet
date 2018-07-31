using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCircularMove : MonoBehaviour {
    float circularTimer;
    float speed;//linear move speed
    public Vector3 target;
    float circularSpeed;
    bool endLiner;
	// Use this for initialization
	void Start () {
        speed = 1f;
        endLiner = false;
        circularSpeed = 2;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        if (endLiner)
        {
            CircularMove();
            
        }
        else { LinearMove(transform.gameObject, target); }
    }

    void LinearMove(GameObject go,Vector3 target)
    {
        go.transform.position = Vector3.MoveTowards(go.transform.position,target,speed*Time.deltaTime);
        if (go.transform.position == target)
        {
            endLiner = true;
        }
    }

    void CircularMove()
    {
        Vector3 pos;
        pos = transform.position;
        circularTimer += Time.deltaTime;
        pos.x -= Mathf.Sin(circularTimer*circularSpeed)*0.03f;
        pos.y -= Mathf.Cos(circularTimer*circularSpeed)*0.03f;
        transform.position = pos;
    }
}
