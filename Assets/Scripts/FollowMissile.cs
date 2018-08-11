using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMissile : Weapon {


    //direction which missile will move to ;
	// Use this for initialization
	void Start () {
        transform.gameObject.name = GameManager.gm.NameReplace(transform.gameObject);
        attackPower = basicAttackPower;
        setRate = 1.0f;
        target = GetTarget();
        StartCoroutine(Movement());
        StartCoroutine(SelfDisable());
        targetMissing = false;
        shot = GameObject.Find("Player").GetComponent<Shot>();
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Monster")
        {
                other.gameObject.SendMessage("ApplyDamage", basicAttackPower,SendMessageOptions.DontRequireReceiver);
                Destroy(this.gameObject);
        }   
    }

}
