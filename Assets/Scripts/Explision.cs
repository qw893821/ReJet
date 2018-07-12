using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void Awake()
    {
        StartCoroutine(SelfDestroyer(0.5f));
    }
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SelfDestroyer(float time)
    {
        
        Destroy(this.transform.gameObject, time);
        yield return null;
    }
}
