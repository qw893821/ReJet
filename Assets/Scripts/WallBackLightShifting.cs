using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBackLightShifting : MonoBehaviour {
    SpriteRenderer sr;
    float shifTime;
    float shifTimer;
	// Use this for initialization
	void Start () {
        sr = transform.GetComponent<SpriteRenderer>();
        shifTime=2.0f;
	}
	
	// Update is called once per frame
	void Update () {
        RedShifting();
	}

    void RedShifting()
    {
        Color color;
        shifTimer += Time.deltaTime;
        color = new Color(Mathf.Lerp(0, 1, shifTimer / shifTime),0,0);
        sr.color = color;
        if (shifTimer >shifTime)
        {
            shifTimer -= shifTime;
        }
    }
}
