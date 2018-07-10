using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    float speed;
    Vector3 target;
    GameObject player;
    Vector2 dir;
	// Use this for initialization
	void Awake () {
        speed = 5f;
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        BulletMove();
	}


    void BulletMove()
    {
        transform.Translate(dir*speed*Time.deltaTime);
    }

    public void SetProperity()
    {
        target = player.transform.position;
        dir = (target - transform.position).normalized;
    }
}
