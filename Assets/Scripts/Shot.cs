using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    public List<GameObject> bullets;
    public struct PlayerBullet {
        public int index;
        public GameObject currentbullet;

        public void IndexIncrease(List<GameObject> golist)
        {
            List<GameObject> bullets;
            bullets = golist;
            if (index >= bullets.Count-1)
            {
                index = 0;
            }
            else { index++; }
            
        }
        public void IndexDecrease(List<GameObject> golists)
        {
            List<GameObject> bullets;
            bullets = golists;
            if (index <= 0)
            {
                index = bullets.Count-1;
            }
            else { --index; }
        }
    }
    PlayerBullet bullet;
    public GameObject heavyWeapon;
    //bullet shoot speed when press and hold button
    float time = 0.2f;
    float bulletTimer;
    float bulletattackSpeed;
    float heavyattackSpeed;
    float heavyTimer;
    float tempPowerUpTime;
    public float tempPowerMod;

    public List<BulletGarbge> bulletsgarbge;
    bool heavyReady;
    private void Awake()
    {
        bullet.index = 0;
        GetBulletProperity(bullet.index);
        bulletsgarbge = new List<BulletGarbge>();
        
    }

    private void Start()
    {
        heavyReady = false;
        bulletTimer = 0;
        heavyTimer = 0;
        tempPowerUpTime = 5.0f;
        tempPowerMod = 1.0f;
    }

    // Update is called once per frame
    void Update() {
        Fire();
        WeaponSwitch();
    }

    //fire bullet
    void Fire()
    {
        heavyReady = HeavryWeaponCheck();
        if (Input.GetKey("j"))
        {
            HeavyWeaponInster();
        }
        if (Input.GetKeyDown("j"))
        {
            //InstBullet(bullet.currentbullet);
            //InstBullet(heavyWeapon);
            InvokeRepeating("BulletInster", 0f, 0.016f);
            //InvokeRepeating("HeavyWeaponInster", 0f, 0.016f);
        }
        else if (Input.GetKeyUp("j"))
        {
            CancelInvoke("BulletInster");
            //CancelInvoke("HeavyWeaponInster");
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
    //use broadcast message to make it work for weapon with multi sub weapon(child object)
    void InstBullet(GameObject weapongo)
    {
        if (weapongo)
        {
            if (GameManager.gm.GarbageFind(/*GameManager.gm.bullets*/bulletsgarbge, weapongo, weapongo.name).isCreated)
            {
                int count;
                count = /*GameManager.gm.bullets*/bulletsgarbge[GameManager.gm.GarbageFind(/*GameManager.gm.bullets*/bulletsgarbge, weapongo, weapongo.name).garbgeIndex].collection.Count;
                if (count == 0)
                {
                    //GameObject go;
                    //go = Instantiate(weapongo/*, transform.position, Quaternion.identity*/);
                    //go.BroadcastMessage("SetProperity", tempPowerMod);
                    InstGO(weapongo);
                }
                else
                {
                    /*GameManager.gm.bullets*/
                    bulletsgarbge[GameManager.gm.GarbageFind(/*GameManager.gm.bullets*/bulletsgarbge, weapongo, weapongo.name).garbgeIndex].collection[count - 1].SetActive(true);
                    /*GameManager.gm.bullets*/
                    bulletsgarbge[GameManager.gm.GarbageFind(/*GameManager.gm.bullets*/bulletsgarbge, weapongo, weapongo.name).garbgeIndex].collection[count - 1].SendMessage("SetProperity", tempPowerMod);
                    //GameManager.gm.bullets[GameManager.gm.GarbageFind(GameManager.gm.bullets, bullet, bullet.name).garbgeIndex].collection[0].transform.position = transform.position;
                    /*GameManager.gm.bullets*/
                    bulletsgarbge[GameManager.gm.GarbageFind(/*GameManager.gm.bullets*/bulletsgarbge, weapongo, weapongo.name).garbgeIndex].collection.RemoveAt(count - 1);
                }
            }
            else
            {
                //GameObject go;
                //go = Instantiate(weapongo/*, transform.position, Quaternion.identity*/);
                //go.BroadcastMessage("SetProperity", tempPowerMod);
                InstGO(weapongo);
            }
        }

        else { return; }
    }
    
    void InstGO(GameObject weapongo)
    {
        GameObject go;
        go = Instantiate(weapongo/*, transform.position, Quaternion.identity*/);
        go.BroadcastMessage("SetProperity", tempPowerMod);
    }

    void BulletInster()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= bulletattackSpeed)
        {
            InstBullet(bullet.currentbullet);
            bulletTimer = 0;
        }
    }

    void HeavyWeaponInster()
    {
        if (heavyReady)
        {
            InstBullet(heavyWeapon);
            heavyReady = false;
        }
    }

    bool HeavryWeaponCheck()
    {
        if (!heavyReady)
        {
            heavyTimer += Time.deltaTime;
            if (heavyTimer >= heavyattackSpeed)
            {
                heavyTimer = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    void WeaponSwitch()
    {
        if (Input.GetKeyDown("u"))
        {
            bullet.IndexDecrease(bullets);
            GetBulletProperity(bullet.index);
        }
        else if (Input.GetKeyDown("o"))
        {
            bullet.IndexIncrease(bullets);
            GetBulletProperity(bullet.index);
        }
    }

    void GetBulletProperity(int i)
    {
        bullet.currentbullet = bullets[i];
        bulletattackSpeed = bullet.currentbullet.GetComponent<Bullet>().attackSpeed;
        heavyattackSpeed = heavyWeapon.GetComponent<FollowMissile>().attackSpeed;
    }
}
