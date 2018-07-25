using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Weapon {
    GameObject player;
    //enemy bullet disable timer
    float selfDisableTimer;
	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player");
    }
    private void Start()
    {
        transform.gameObject.name = GameManager.gm.NameReplace(transform.gameObject);

        speed = 5f;
        
    }
    // Update is called once per frame
    void Update () {
        BulletMove();
        selfDisableTimer += Time.deltaTime;
        if (selfDisableTimer >= 5f)
        {
            SelfDisable();
        }
	}


    void BulletMove()
    {
        transform.Translate(dir*speed*Time.deltaTime);
    }

    public void SetProperity()
    {
        target = player;
        dir = (target.transform.position - transform.position).normalized;
    }

    //void SelfDisable()
    //{
    //    //if (GameManager.gm.bullets.Count == 0)
    //    //{
    //    //    GameManager.gm.bullets.Add(new BulletGarbge());
    //    //    GameManager.gm.bullets[0].bulletName = transform.gameObject.name;
    //    //    GameManager.gm.bullets[0].collection.Add(transform.gameObject);
    //    //    transform.gameObject.SetActive(false);
    //    //}
    //    //else
    //    //{
    //    //    foreach (BulletGarbge bg in GameManager.gm.bullets.ToArray())
    //    //    {
    //    //        if (bg.bulletName == transform.gameObject.name)
    //    //        {
    //    //            bg.collection.Add(transform.gameObject);
    //    //            transform.gameObject.SetActive(false);
    //    //        }
    //    //        else
    //    //        {
    //    //            int count = GameManager.gm.bullets.Count;
    //    //            GameManager.gm.bullets.Add(new BulletGarbge());
    //    //            GameManager.gm.bullets[count].bulletName = transform.gameObject.name;
    //    //            GameManager.gm.bullets[count].collection.Add(transform.gameObject);
    //    //            transform.gameObject.SetActive(false);
    //    //        }
    //    //    }
    //    //}
    //    Destroy(this.gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(GameManager.gm.explision_Anim,transform.position,Quaternion.identity);
            collision.transform.gameObject.SendMessage("Damaged",basicAttackPower);
        }
    }
}
