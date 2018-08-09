using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon {
    //float attackPower;
    //self disable timer;
    //power modfier
    //public float temp_PowerMod;
    //float tempModTimer;
    // Use this for initialization
    //GameObject player;
    //weapon w/o track ability will not require target 
    void Start() {
        //temp_PowerMod = 1.0f;
        attackPower = basicAttackPower;
        //tempModTimer = 5.0f;
        transform.gameObject.name = GameManager.gm.NameReplace(transform.gameObject);
        StartCoroutine(Movement());
        StartCoroutine(SelfDisable());
        //player = GameObject.Find("Player");
        shot = GameObject.Find("Player").GetComponent<Shot>();

    }

    
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update() {
        //BulletMove();
        //selfDestroyTimer += Time.deltaTime;
        //{
        //    if (selfDestroyTimer >= selfDestroyTime)
        //    {
        //        SelfDisable();
        //    }
        //}
    }

    public override void Launch()
    {
        Vector2 lunchPos;
        Vector2 goPos;
        goPos = transform.position;
        lunchPos = goPos + new Vector2(speed, 0f);
        transform.position = Vector2.MoveTowards(transform.position, lunchPos, speed * Time.deltaTime);
    }

    public override IEnumerator Movement()
    {
        InvokeRepeating("Launch", 0f, 0.03f);
        yield return null;
    }

    private void OnEnable()
    {
        selfDestroyTimer = 0f;

    }
    
    void BulletMove()
    {
        transform.position += new Vector3(speed, 0, 0f) * Time.deltaTime;
    }

    //bullet last a peroid of time
    //void SelfDisable()
    //{
    //    if (GameManager.gm.bullets.Count == 0)
    //    {
    //        CreateBulletCollection(0);
    //    }
    //    else
    //    {
    //        GarbageReuse();
    //    }
    //}

    //create the new bullet garbage
    void CreateBulletCollection(int c)
    {
        shot.bulletsgarbge.Add(new BulletGarbge());
        shot.bulletsgarbge[c].bulletName = transform.gameObject.name;
        shot.bulletsgarbge[c].collection.Add(transform.gameObject);
        transform.gameObject.SetActive(false);
    }

    //when there is a matched garbage collection, take from the collection
    void GarbageReuse()
    {
        foreach (BulletGarbge bg in shot.bulletsgarbge)
        {
            if (bg.bulletName == transform.gameObject.name)
            {

                bg.collection.Add(transform.gameObject);
                transform.gameObject.SetActive(false);
            }
            else
            {
                int count = shot.bulletsgarbge.Count;
                CreateBulletCollection(count - 1);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.tag == "Monster")
        //{
        //    BulletHit(col, "vuln");
        //}
        //else
        //{
        //    GameObject go;
        //    go = Instantiate(GameManager.gm.explision_Anim, transform.position, Quaternion.identity);
        //    go.SendMessage("ChangeSprite", "invuln");
        //}
        BulletHit(col);
    }
    void BulletHit(Collider2D col)
    {
        if (col.tag == "Monster")
        {
            col.gameObject.SendMessage("ApplyDamage", attackPower);
            HitDisable();
            GameObject go;
            go = Instantiate(GameManager.gm.explision_Anim, transform.position, Quaternion.identity);
            go.SendMessage("ChangeSprite", "vuln");
        }
        else if (col.tag == "Destroyable")
        {
            HitDisable();
            GameObject go;
            go = Instantiate(GameManager.gm.explision_Anim, transform.position, Quaternion.identity);
            go.SendMessage("ChangeSprite", "vuln");
            Destroy(col.gameObject);
        }
        else
        {
            Debug.Log(col.name);
            HitDisable();
            GameObject go;
            go = Instantiate(GameManager.gm.explision_Anim, transform.position, Quaternion.identity);
            go.SendMessage("ChangeSprite", "invuln");
        }
    }
}
