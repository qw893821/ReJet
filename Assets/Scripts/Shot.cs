using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    public GameObject bullet;
    //bullet shoot speed when press and hold button
    float time = 0.2f;
    float timer;

    private void Start()
    {
        timer = 0f;
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
                if (GameManager.gm.GarbageFind(GameManager.gm.bullets,bullet,bullet.name).isCreated)
                {
                    
                    if (GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection.Count == 0)
                    {
                        Instantiate(bullet, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection[0].SetActive(true);
                        GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection[0].transform.position = transform.position;
                        GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection.RemoveAt(0);
                    }
                }
                else
                {
                    
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    
                }
                timer = 0;
            }
        }
        if (Input.GetKeyDown("j"))
        {
            if (GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).isCreated)
            {
                if (GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection.Count == 0)
                {
                    Instantiate(bullet, transform.position, Quaternion.identity);
                }
                else
                {
                    GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection[0].SetActive(true);
                    GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection[0].transform.position = transform.position;
                    GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection.RemoveAt(0);
                }
            }
            else
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
            timer = 0;
        }
        
    }

    
}
