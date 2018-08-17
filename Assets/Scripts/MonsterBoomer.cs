using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoomer :Monsters {
    //public GameObject boomer;
	// Use this for initialization
	void Start () {
        died = false;
	}

    
    //overrid(not exactly) the OnEnable() function in Monster to avoid the on enable Bullet instantiate
    private void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update () {
		
	}

    private void OnDisable()
    {
        //Invoke("CancelInvoke",0f);
        //CancelInvoke();
        Hiden();
    }

    protected override void Die()
    {
        base.Die();
        if (died)
        {
            Instantiate(bullet,transform.position,Quaternion.identity);
            Debug.Log("boom");
        }
    }
}
