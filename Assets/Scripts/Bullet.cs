using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    float speed;
    //attack power of the bullet;
    public float attackPower;
	// Use this for initialization
	void Start () {
        speed = 5f;
        Invoke("SelfDestroy",5f);
	}
	
	// Update is called once per frame
	void Update () {
        BulletMove();
    }

    

    void BulletMove()
    {
        transform.position += new Vector3(speed,0,0f)*Time.deltaTime;
    }

    //bullet last a peroid of time
    void SelfDestroy()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("enter");
        if (col.tag == "Monster")
        {
            col.gameObject.SendMessage("ApplyDamage", attackPower);
            SelfDestroy();
        }
    }
    
}
