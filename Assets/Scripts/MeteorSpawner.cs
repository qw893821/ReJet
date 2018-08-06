using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {
    public GameObject meteor;
	// Use this for initialization
	void Start () {
		
	}
	void Awake()
    {
        
        
    }
	// Update is called once per frame
	void Update () {
		
	}

    
    void Spawn()
    {
        float range;
        range = Random.Range(-4.5f, 4.5f);
        Instantiate(meteor, transform.position + new Vector3(0, range, 0),Quaternion.Euler(0,0,45f));
        if (!this.gameObject.activeSelf)
        {
            Invoke("CancelInvoke",0f);
        }
       
    }

    private void OnEnable()
    {
        InvokeRepeating("Spawn", 0.5f, 0.5f);
    }
}
