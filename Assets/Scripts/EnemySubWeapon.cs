using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySubWeapon: Weapon {

	// Use this for initialization
	void Start () {
        StartCoroutine(SelfDisable());
        dir = transform.right;
        player = GameManager.gm.player;
    }


    // Update is called once per frame
    void Update () {
        TransDirMove();
    }

    //private void Move()
    //{
    //    Vector3 target;
    //    target = transform.position + dir;
    //    transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.SendMessage("Damaged",basicAttackPower);
            HitDisable();
        }
    }
}
