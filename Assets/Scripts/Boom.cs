using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Bullet {
    public GameObject boomexplosion;
	// Use this for initialization
	void Start () {
        player = GameManager.gm.player;
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
        if (col.tag == "Destroyable")
            {
                Destroy(col.gameObject);
            }
            GameObject go;
            Vector3 fixpos;
            go = Instantiate(boomexplosion, transform.position, Quaternion.identity);
            fixpos = go.transform.position;
            go.GetComponent<DurationWeapon>().SetProperity(player.GetComponent<Shot>().tempPowerMod);
            go.transform.position = fixpos;
            HitDisable();

        
    }
}
