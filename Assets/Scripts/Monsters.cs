using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public GameObject bullet;
    public float healthPoint;
    public float lastingtime;
    bool died;
    // Use this for initialization
    private void Start()
    {
        GameManager.gm.NameReplace(transform.gameObject);
        InvokeRepeating("InstBullet", 1f, 2f);
        //died = false;
    }

    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        Invoke("CancelInvoke",0f);
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
            Instantiate(GameManager.gm.power_Loot,transform.position,Quaternion.identity);
            //Hiden();
            GameManager.gm.explosionSoundEffect.GetComponent<AudioSource>().Play();
            Invoke("CancelInvoke", 0f);
            transform.gameObject.SetActive(false);
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

    void Hiden()
    {
        transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        foreach(SpriteRenderer sr in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            sr.enabled = false;
        }
        
    }
}
