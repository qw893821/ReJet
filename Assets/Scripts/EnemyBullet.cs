using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    float speed;
    Vector3 target;
    GameObject player;
    Vector2 dir;
    public GameObject explision_Anim;
    //enemy bullet disable timer
    float timer;
	// Use this for initialization
	void Awake () {
        speed = 5f;
        player = GameObject.Find("Player");
        Invoke("SelfDisable",5f);
	}
	
	// Update is called once per frame
	void Update () {
        BulletMove();
        timer += Time.deltaTime;
        if (timer >= 5f)
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
        target = player.transform.position;
        dir = (target - transform.position).normalized;
    }

    void SelfDisable()
    {
        Destroy(transform.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(explision_Anim,transform.position,Quaternion.identity);
        }
    }
}
