using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRotateFollow : MonoBehaviour {
    public Vector3 dirfixValue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
	}

    void Rotate()
    {
        Vector3 rot;
        rot = transform.parent.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(rot);
        transform.rotation *= Quaternion.Euler(dirfixValue);
    }
}
