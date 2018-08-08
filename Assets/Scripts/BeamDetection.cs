using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamDetection : MonoBehaviour {
    DirectionalBeam db;
    // Use this for initialization
    private void Awake()
    {
        db = transform.GetComponentInParent<DirectionalBeam>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == GameManager.gm.player)
        {
            Instantiate(GameManager.gm.explision_Anim, col.contacts[0].point, Quaternion.identity);
            col.transform.gameObject.SendMessage("Damaged", db.basicAttackPower);
            db.HitDisable();
        }
    }
}
