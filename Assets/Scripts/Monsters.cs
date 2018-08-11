using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public GameObject bullet;
    public float healthPoint;
    public float lastingtime;
    public bool died;
    public Collider2D col;
    public float shotStartDelay;
    public float idleTime;
    // Use this for initialization
    private void Start()
    {
       // GameManager.gm.NameReplace(transform.gameObject);
        //InvokeRepeating("InstBullet", 1f, 2f);
        //died = false;
    }

    private void OnEnable()
    {
        //if there is a bullet attacked to the gameobject, then enable the shooting gammick
        if (bullet)
        {
            InvokeRepeating("InstBullet", shotStartDelay, idleTime);
        }
    }

    private void OnDisable()
    {
        //Invoke("CancelInvoke",0f);
        CancelInvoke();
        Hiden();
    }

    void ApplyDamage(float ap)
    {
        healthPoint -= ap;
        Die();
    }

    void DurationDamage(float ap)
    {
        healthPoint -= ap * Time.deltaTime;
        Die();
    }


    void Die()
    {
        if (healthPoint <= 0)
        {
            died = true;
            Instantiate(GameManager.gm.power_Loot,transform.position,Quaternion.identity);
            GameManager.gm.explosionSoundEffect.GetComponent<AudioSource>().Play();
            //Invoke("CancelInvoke", 0f);
            //timeline will enable gameobject when
            this.enabled = false;
            Hiden();
            transform.gameObject.SetActive(false);
        }
    }

    void InstBullet()
    {
        GameObject bullet_Clone;
        bullet_Clone = Instantiate(bullet, transform.position, Quaternion.identity);
        var eb = bullet_Clone.GetComponent<EnemyBullet>();
        if (eb)
        {
            eb.SetProperity();
        }

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
        col.enabled = false;
        foreach(SpriteRenderer sr in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            sr.enabled = false;
            //Invoke("CancelInvoke", 0f);
        }
        MeshRenderer mr;
        mr = transform.GetComponent<MeshRenderer>();
        if (mr)
        {
            mr.enabled = false;
        }

    }
}
