﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    public GameObject bullet;
    //bullet shoot speed when press and hold button
    float time = 0.2f;
    float timer;
    float tempPowerUpTime;
    public float tempPowerMod;
    private void Start()
    {
        timer = 0f;
        tempPowerUpTime = 5.0f;
        tempPowerMod = 1.0f;
    }

    // Update is called once per frame
    void Update () {
        Fire();
    }

    //fire bullet
    void Fire()
    {
        if (Input.GetKey("j"))
        {
            timer += Time.deltaTime;
            if (timer >= time)
            {
                InstBullet();
            }
        }
        if (Input.GetKeyDown("j"))
        {
            InstBullet();
        }
        
    }

    void PowerUpCounter()
    {
        StartCoroutine("TempPowerUPCounter");
    }

    IEnumerator TempPowerUPCounter()
    {
        tempPowerMod = 2.0f;
        yield return new WaitForSeconds(tempPowerUpTime);
        tempPowerMod = 1.0f;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Loot")
    //    {
    //        collision.gameObject.SendMessage("Promote", transform.gameObject);
    //    }
    //}

    void InstBullet()
    {
        if (GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).isCreated)
        {

            if (GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection.Count == 0)
            {
                GameObject go;
                go=Instantiate(bullet/*, transform.position, Quaternion.identity*/);
                go.SendMessage("SetProperity",tempPowerMod);
            }
            else
            {
                GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection[0].SetActive(true);
                GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection[0].SendMessage("SetProperity",tempPowerMod);
                //GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection[0].transform.position = transform.position;
                GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection.RemoveAt(0);
            }
        }
        else
        {
            GameObject go;
            go = Instantiate(bullet/*, transform.position, Quaternion.identity*/);
            go.SendMessage("SetProperity", tempPowerMod);
        }
        timer = 0;
    }
}
