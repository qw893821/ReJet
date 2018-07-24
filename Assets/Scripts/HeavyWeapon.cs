using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyWeapon : MonoBehaviour {
    private float _setRate;
    public float setRate
    {
        get { return _setRate; }
        set { _setRate = value; }
    }
    //basic set time
    public float setTime;
    public float speed;
    GameObject target;
    public float attackPower;
	// Use this for initialization
	void Start () {
        setRate = 1.0f;
        target = GetTarget();
        StartCoroutine(Movement());
        StartCoroutine(SelfDisable());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Launch()
    {
        Vector2 lunchPos;
        Vector2 goPos;
        goPos = transform.position;
        lunchPos = goPos + new Vector2(0,1.0f);
        transform.position = Vector2.MoveTowards(transform.position,lunchPos,1.0f*Time.deltaTime);
    }

    float SetTime()
    {
        return setTime *setRate;
    }

    IEnumerator Movement()
    {
        InvokeRepeating("Launch",0f,0.1f);
        yield return new WaitForSeconds(SetTime());
        CancelInvoke();
        InvokeRepeating("MoveTowardTarget",0f,0.1f);
    }

    GameObject GetTarget()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Monster");
        GameObject closest;
        float distance;
        closest = null;
        distance = Mathf.Infinity;
        foreach(GameObject go in gos)
        {
            float curdistance;
            curdistance = Vector2.Distance(transform.position,go.transform.position);
            if (curdistance < distance)
            {
                distance = curdistance;
                closest = go;
            }
        }
        return closest;
    }

    void MoveTowardTarget()
    {
        if (target)
        {
            transform.position = Vector2.MoveTowards(transform.position,target.transform.position,speed*Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(transform.forward, transform.position- target.transform.position);
            transform.rotation *= Quaternion.Euler(0, 0, -90.0f);
        }
        else
        {
            //doing the same thing like launch
            Launch();
        }
    }

    void SetProperity(float mod)
    {
        //attackPower = PromotePower(mod);
        transform.position = GameManager.gm.shot.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Monster")
        {
                other.gameObject.SendMessage("ApplyDamage", attackPower);
                Debug.Log("missile hit");
                Destroy(this.gameObject);
        }   
    }

    IEnumerator SelfDisable()
    {

        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
