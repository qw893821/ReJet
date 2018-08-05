using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1BossMovement : MonoBehaviour {
    //Vector3 targetPos;
    GameObject player;
    public float speed;
	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        LinearMove();
	}

    Vector3 GetTargetPos()
    {
        Vector3 targetPos;
        targetPos = player.transform.position;
        //pos fix because boss will stay at the very left of this game
        //at least level 1 boss will do that so far
        targetPos = new Vector3(transform.position.x, targetPos.y, 0f);
        return targetPos;
    }


    void LinearMove()
    {
        transform.position = Vector3.MoveTowards(transform.position,GetTargetPos(),speed*Time.deltaTime);
    }
}
