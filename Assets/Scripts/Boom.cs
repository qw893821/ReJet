using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Bullet {
    public GameObject boomexplosion;
	// Use this for initialization
	void Start () {
        transform.gameObject.name = GameManager.gm.NameReplace(transform.gameObject);
        StartCoroutine(Movement());
        StartCoroutine(SelfDisable());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        BulletHit(col);
    }

    public override void BulletHit(Collider2D col)
    {
        Instantiate(boomexplosion,transform.position,Quaternion.identity);
        HitDisable();
        Debug.Log("boom boom");
    }
}
