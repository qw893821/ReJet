using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneShot : Shot {

	// Use this for initialization
	void Start () {
        bulletTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        Fire();
	}

    protected override void Fire()
    {
        if (Input.GetKeyDown("j"))
        {
            InvokeRepeating("BulletInster",0f,0.016f);
        }
        else if (Input.GetKeyUp("j"))
        {
            CancelInvoke("BulletInster");
        }
        
    }

    protected override void BulletInster()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= bulletattackSpeed)
        {
            Instantiate(bullets[0], transform.position, Quaternion.identity);
            bulletTimer = 0f;
        }
    }
}
