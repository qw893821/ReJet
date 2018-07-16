﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public GameObject bullet;
    public float healthPoint;
    public float lastingtime;
    public  GameObject newBullet;
    // Use this for initialization

    private void Awake()
    {
        GameManager.gm.NameReplace(transform.gameObject);
        InvokeRepeating("InstBullet",1f,2f);
        Invoke("CancelInvoke",lastingtime);
    }
    // Update is called once per frame
    void Update()
    {

    }

    void ApplyDamage(float ap)
    {
        healthPoint -= ap;
        Die();
    }


    void Die()
    {
        if (healthPoint <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void InstBullet()
    {

        GameObject bullet_Clone;
        bullet_Clone = Instantiate(bullet, transform.position, Quaternion.identity);
        bullet_Clone.GetComponent<EnemyBullet>().SetProperity();

        //GameObject bullet_Clone;
        //if (GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).isCreated)
        //{

        //    if (GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection.Count == 0)
        //    {
        //        bullet_Clone = Instantiate(bullet, transform.position, Quaternion.identity);
        //        bullet_Clone.GetComponent<EnemyBullet>().SetProperity();
        //        Debug.Log("find");
        //    }
        //    else
        //    {
        //        GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection[0].SetActive(true);
        //        GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection[0].transform.position = transform.position;
        //        GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection[0].GetComponent<EnemyBullet>().SetProperity();
        //        GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection.RemoveAt(0);

        //    }
        //}
        //else
        //{

        //    bullet_Clone = Instantiate(bullet, transform.position, Quaternion.identity);
        //    bullet_Clone.GetComponent<EnemyBullet>().SetProperity();
        //    Debug.Log("no found");
        //}


    }

}
