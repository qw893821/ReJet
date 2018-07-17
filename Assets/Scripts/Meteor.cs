using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {
    public float h, v;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    private void OnEnable()
    {
        h = Random.Range(4f,7f);
    }

    void Movement()
    {
        Vector3 pos;
        pos = transform.position;
        pos.x -= h*Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(GameManager.gm.explision_Anim,transform.position,Quaternion.identity);
        }
    }
}
