using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSetter : Monsters {
    private void OnEnable()
    {
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void InstBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
