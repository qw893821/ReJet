using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    public GameObject bullet;
    public GameObject heavyWeapon;
    //bullet shoot speed when press and hold button
    float time = 0.2f;
    float bulletTimer;
    float bulletattackSpeed;
    float heavyattackSpeed;
    float heavyTimer;
    float tempPowerUpTime;
    public float tempPowerMod;

    private void Awake()
    {
        bulletattackSpeed = bullet.GetComponent<Bullet>().attackSpeed;
        heavyattackSpeed = heavyWeapon.GetComponent<FollowMissile>().attackSpeed;
    }
    private void Start()
    {
        bulletTimer=0;
        heavyTimer=0;
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
        //if (Input.GetKey("j"))
        //{
            
        //}
        if (Input.GetKeyDown("j"))
        {
            InvokeRepeating("BulletInster",0f,0.016f);
            InvokeRepeating("HeavyWeaponInster", 0f, 0.016f);
        }
        else if (Input.GetKeyUp("j"))
        {
            CancelInvoke("BulletInster");
            CancelInvoke("HeavyWeaponInster");
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

    //weapon is the go which will instantiated, time is the time between each shot
    void InstBullet(GameObject weapongo)
    {
        if (weapongo)
        {
                if (GameManager.gm.GarbageFind(GameManager.gm.bullets, weapongo, weapongo.name).isCreated)
                {
                    int count;
                    count = GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, weapongo, weapongo.name).garbgeIndex].collection.Count;
                    if (count == 0)
                    {
                        GameObject go;
                        go = Instantiate(weapongo/*, transform.position, Quaternion.identity*/);
                        go.SendMessage("SetProperity", tempPowerMod);
                    }
                    else
                    {
                        GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, weapongo, weapongo.name).garbgeIndex].collection[count - 1].SetActive(true);
                        GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, weapongo, weapongo.name).garbgeIndex].collection[count - 1].SendMessage("SetProperity", tempPowerMod);
                        //GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection[0].transform.position = transform.position;
                        GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, weapongo, weapongo.name).garbgeIndex].collection.RemoveAt(count - 1);
                    }
                }
                else
                {
                    GameObject go;
                    go = Instantiate(weapongo/*, transform.position, Quaternion.identity*/);
                    go.SendMessage("SetProperity", tempPowerMod);
                }
            }
        
        else { return ; }
        
    }

    void BulletInster()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= bulletattackSpeed)
        {
            InstBullet(bullet);
            bulletTimer = 0;
        }
    }

    void HeavyWeaponInster()
    {
        heavyTimer += Time.deltaTime;
        if (heavyTimer >= heavyattackSpeed)
        {
            InstBullet(heavyWeapon);
            heavyTimer = 0;
        }
    }
}
