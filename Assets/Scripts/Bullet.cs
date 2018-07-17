using System.Collections;
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
        speed = 8.0f;
	}

    
    private void Awake()
    {
        transform.gameObject.name = GameManager.gm.NameReplace(transform.gameObject);
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
        if (GameManager.gm.bullets.Count == 0)
        {
            CreateBulletCollection(0);
        }
        else
        {
            GarbageReuse();
        }
    }

    //create the new bullet garbage
    void CreateBulletCollection(int c)
    {
        GameManager.gm.bullets.Add(new BulletGarbge());
        GameManager.gm.bullets[c].bulletName = transform.gameObject.name;
        GameManager.gm.bullets[c].collection.Add(transform.gameObject);
        transform.gameObject.SetActive(false);
    }

    //when there is a matched garbage collection, take from the collection
    void GarbageReuse()
    {
        foreach (BulletGarbge bg in GameManager.gm.bullets)
        {
            if (bg.bulletName == transform.gameObject.name)
            {

                bg.collection.Add(transform.gameObject);
                transform.gameObject.SetActive(false);
            }
            else
            {
                int count = GameManager.gm.bullets.Count;
                CreateBulletCollection(count - 1);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Monster")
        {
            BulletHit(col);
        }
    }
    
    void BulletHit(Collider2D col)
    {
        col.gameObject.SendMessage("ApplyDamage", attackPower);
        SelfDisable();
        Instantiate(GameManager.gm.explision_Anim, transform.position, Quaternion.identity);
    }
    
}
