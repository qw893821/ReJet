using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationWeapon : Bullet {

	// Use this for initialization
	void Start () {
        StartCoroutine(SelfDisable());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
    private void OnTriggerStay2D(Collider2D col)
    {
        BulletHit(col);
    }

    public override void BulletHit(Collider2D col)
    {
        if (col.tag == "Monster")
        {
            col.gameObject.SendMessage("DurationDamage", attackPower,SendMessageOptions.DontRequireReceiver);
        }

    }

    public override void SetProperity(float mod)
    {
        attackPower = PromotePower(mod);
    }
}
