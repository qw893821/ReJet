using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalBeam : MonoBehaviour {
    LineRenderer lr;
    Vector3 startPos;
    Vector3 endPos;

    public float beamSpeed;
    //beam length is equals to beamspeed * time, so beamLength is actuall the time of each shoot
    float beamLength;
    public float beamTime;
    public float duration;
    PolygonCollider2D poly;
    GameObject player;
    //direction of beam
    Vector3 dir;
    public GameObject detectionCollider;

	// Use this for initialization
	void Start () {
        lr = transform.GetComponent<LineRenderer>();
        player = GameObject.Find("Player");
        startPos = transform.position;
        endPos = transform.position;
        dir = player.transform.position - transform.position;
        GameManager.gm.NameReplace(transform.gameObject);
        poly = transform.GetComponent<PolygonCollider2D>();
        //detectionCollider = GameObject.Find("DetectionCollider");
	}
	
	// Update is called once per frame
	void Update () {
        RenderBeam();
        ColliderUpdater();

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

    //the collider will change based on the beam length
    void ColliderUpdater()
    {
        Vector3 scale;
        float angle;
        Vector3 pos;
        angle = Vector3.Angle(transform.right,dir);
        //1.5f is a value based on test. 
        //scale = new Vector3(beamLength*beamSpeed/1.5f,0.5f,1.0f);
        scale = new Vector3(Vector3.Distance(endPos,startPos),0.5f,1f);
        detectionCollider.transform.localScale = scale;
        //detectionCollider.transform.Rotate(dir); /*=*/ /*Quaternion.Euler(0,0,angle);*/
        Quaternion rotation = Quaternion.LookRotation(-dir);
        rotation *= Quaternion.Euler(0,-90,0);
        detectionCollider.transform.rotation = rotation;
        pos = new Vector3((startPos.x+endPos.x)/2, (startPos.y + endPos.y) / 2, (startPos.z + endPos.z) / 2);
        detectionCollider.transform.position = pos;
    }
}
