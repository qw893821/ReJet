using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDetection : MonoBehaviour {
    float attackPower;
	// Use this for initialization
	void Start () {
        //touch boundary case instant death
        attackPower = Mathf.Infinity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.SendMessage("Damaged",attackPower);
        }
    }
}
