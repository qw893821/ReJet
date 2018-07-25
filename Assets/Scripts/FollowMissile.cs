using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMissile : Weapon {
    private float _setRate;
    public float setRate
    {
        get { return _setRate; }
        set { _setRate = value; }
    }
    //basic set time
    public float setTime;

    public float selfDisableTimer;

    bool targetMissing;
    //direction which missile will move to ;
    Vector3 dir;
	// Use this for initialization
	void Start () {
        setRate = 1.0f;
        target = GetTarget();
        StartCoroutine(Movement());
        StartCoroutine(SelfDisable());
        targetMissing = false;
        selfDisableTimer = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Launch()
    {
        Vector2 lunchPos;
        Vector2 goPos;
        goPos = transform.position;
        lunchPos = goPos + new Vector2(0,1.5f);
        transform.position = Vector2.MoveTowards(transform.position,lunchPos,1.5f*Time.deltaTime);
    }

    float SetTime()
    {
        return setTime *setRate;
    }

    IEnumerator Movement()
    {
        InvokeRepeating("Launch",0f,0.03f);
        yield return new WaitForSeconds(SetTime());
        CancelInvoke();
        InvokeRepeating("MoveTowardTarget",0f,0.03f);
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
                curdistance = Vector2.Distance(transform.position, go.transform.position);
                if (curdistance < distance && !go.GetComponent<Monsters>().died)
                {
                    distance = curdistance;
                    closest = go;
                }
        }
        return closest;
    }

    void MoveTowardTarget()
    {
        //when there is a target
        if (target)
        {
            MoveCheck();
            //transform.position = Vector2.MoveTowards(transform.position,target.transform.position,speed*Time.deltaTime);
            //transform.rotation = Quaternion.LookRotation(transform.forward, transform.position- target.transform.position);
            //transform.rotation *= Quaternion.Euler(0, 0, -90.0f);

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
                other.gameObject.SendMessage("ApplyDamage", basicAttackPower);
                Destroy(this.gameObject);
        }   
    }

    IEnumerator SelfDisable()
    {

        yield return new WaitForSeconds(selfDisableTimer);
        Destroy(this.gameObject);
    }

    void MoveCheck()
    {
        //when target is die during the movement
        if (target.GetComponent<Monsters>().died)
        {
            //when target is missing, get dir only once
            if (targetMissing == false)
            {
                dir=GetDir();
            }
            targetMissing = true;
            transform.Translate(dir*speed*Time.deltaTime);
        }
        //when target is still alive
        else
        {
            dir = GetDir();
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(transform.forward, dir);
            transform.rotation *= Quaternion.Euler(0, 0, 90.0f);
        }
    }

    Vector3 GetDir()
    {
        Vector3 dir;
        dir = (target.transform.position - transform.position).normalized;
        return dir;
    }
}
