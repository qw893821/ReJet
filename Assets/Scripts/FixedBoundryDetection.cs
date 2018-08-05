using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedBoundryDetection: MonoBehaviour {
    public float attackPower;
	// Use this for initialization
	void Start () {
        //touch boundary case instant death
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.SendMessage("Damaged",attackPower);
            Debug.Log("player enter");
        }
    }


}
