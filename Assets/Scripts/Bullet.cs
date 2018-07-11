﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    float speed;
    //attack power of the bullet;
    public float attackPower;
    //self disable timer;
    float timer;
	// Use this for initialization
	void Start () {
        speed = 5f;
        
	}

    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update () {
        BulletMove();
        timer += Time.deltaTime;
        {
            if (timer >= 5f)
            {
                SelfDisable();
                
            }
        }
    }

    private void OnEnable()
    {
        timer = 0f;
    }

    void BulletMove()
    {
        transform.position += new Vector3(speed,0,0f)*Time.deltaTime;
    }

    //bullet last a peroid of time
    void SelfDisable()
    {
        /*foreach(BulletGarbge bg in GameManager.gm.bullets)
        {
            if (bg.bulletName == transform.gameObject.name )
            {
                Debug.Log(bg.collection);
                bg.collection.Add(transform.gameObject);
                transform.gameObject.SetActive(false);
                Debug.Log("Add current");
            }
            else
            {
                int count = GameManager.gm.bullets.Count;
                GameManager.gm.bullets.Add(new BulletGarbge());
                GameManager.gm.bullets[count].bulletName = transform.gameObject.name;
                GameManager.gm.bullets[count].collection.Add(transform.gameObject);
                transform.gameObject.SetActive(false);
                Debug.Log("Create new");
            }
        }
        */
        if (GameManager.gm.bullets.Count == 0)
        {
            GameManager.gm.bullets.Add(new BulletGarbge());
            GameManager.gm.bullets[0].bulletName = transform.gameObject.name;
            GameManager.gm.bullets[0].collection.Add(transform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("enter");
        if (col.tag == "Monster")
        {
            col.gameObject.SendMessage("ApplyDamage", attackPower);
            SelfDisable();
        }
    }
    
    
}