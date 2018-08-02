using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtenstionBeam : MonoBehaviour {
    LineRenderer lr;
    Vector3 startPos;
    Vector3 endPos;

    public float beamSpeed;
    //beam length is equals to beamspeed * time, so beamLength is actuall the time of each shoot
    float beamLength;
    public float beamTime;
    public float duration;

    GameObject player;
    //direction of beam
    Vector3 dir;
	// Use this for initialization
	void Start () {
        lr = transform.GetComponent<LineRenderer>();
        player = GameObject.Find("Player");
        startPos = transform.position;
        endPos = transform.position;
        dir = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        RenderBeam();
	}

    void RenderBeam()
    {
        beamLength += Time.deltaTime;
        endPos += Time.deltaTime * beamSpeed * dir.normalized;
        if (beamLength < beamTime)
        {
            startPos = transform.position;
        }
        else { startPos += Time.deltaTime * beamSpeed * dir.normalized; }
        lr.SetPosition(0,startPos);
        lr.SetPosition(1,endPos);
    }
}
