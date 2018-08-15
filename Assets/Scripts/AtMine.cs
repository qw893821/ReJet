using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtMine : Weapon {
    public ConstantForce2D cf2d;
	// Use this for initialization
	void Start () {
        dir = new Vector3(-1.0f,0,0f);
	}
	
	// Update is called once per frame
	void Update () {
        TransDirMove();
	}

    
    void React()
    {
        if (!cf2d.enabled)
        {
            cf2d.enabled = true;
            Debug.Log("react");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            
            HitPlayer(col);
        }
    }

    
}
