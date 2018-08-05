using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinMovement : MonoBehaviour {
    public float spinSpeed;
    public Vector3 dir;
    public float linearSpeed;
    //public Vector3 linearDir;
    public bool fix;

    //linear move boundary
    public float bleft, bright, bup, bdown;

    Vector3 targetPos;
	// Use this for initialization
	void Start () {
        targetPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Action();
	}

    void Action()
    {
        Spin();
        if (fix)
        {
            return;
        }
        else
        {
            LinearMovement();
        }
    }

    void Spin()
    {
        transform.rotation *= Quaternion.Euler(dir * spinSpeed * Time.deltaTime);
    }

    void LinearMovement()
    {
        //if (fix)
        //{
        //    return;
        //}
        //else {
        //    //Vector3 target;
        //    //target = transform.position + linearDir;
        //    //transform.position = Vector3.MoveTowards(transform.position, target, linearSpeed * Time.deltaTime);
        //}
        if (targetPos == transform.position)
        {
            targetPos = SetTarget();
        }
        transform.position = Vector3.MoveTowards(transform.position,targetPos,linearSpeed*Time.deltaTime);
    }

    Vector3 SetTarget()
    {
        Vector3 targetPos;
        targetPos = new Vector3(Random.Range(-bleft, bright), Random.Range(-bdown, bup), 0f);
        return targetPos;
    }

}
