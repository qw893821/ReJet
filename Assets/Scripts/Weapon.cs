using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Weapon:MonoBehaviour{
    //basicAP of each weapon
    public float basicAttackPower;
    //the actual value after modfier
    public float attackPower;
    //move speed of each weapon;
    public float speed;
    //timer to destory each object
    public float selfDestroyTimer;
    public float selfDestroyTime;
    //attack speed of weapon
    public float attackSpeed;
    //weapon's target pos
    public GameObject target;
    public float fixed_PowerMod;

    public bool targetMissing;
    //direction which missile will move to ;
    protected Vector3 dir;
    //set time of weapon
    public float setTime;
    public float setRate;

    public void SetProperity(float mod)
    {
        attackPower = PromotePower(mod);
        transform.position = GameManager.gm.shot.transform.position;
    }

    public float PromotePower(float mod)
    {
        float ap;
        ap = basicAttackPower * fixed_PowerMod * mod;
        return ap;
    }

    protected GameObject GetTarget()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Monster");
        GameObject closest;
        float distance;
        closest = null;
        distance = Mathf.Infinity;
        foreach (GameObject go in gos)
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
            //doing the same thing like launch when there is no target
            Launch();
        }
    }

    void MoveCheck()
    {
        //when target is die during the movement
        if (target.GetComponent<Monsters>().died)
        {
            //when target is missing, get dir only once
            if (targetMissing == false)
            {
                dir = GetDir();
            }
            targetMissing = true;
            transform.Translate(dir * speed * Time.deltaTime);
        }
        //when target is still alive
        else
        {
            dir = GetDir();
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.LookRotation(transform.forward, dir);
            //transform.rotation *= Quaternion.Euler(0, 0, 90.0f);
        }
        transform.rotation = Quaternion.LookRotation(transform.forward, dir);
        transform.rotation *= Quaternion.Euler(0, 0, 90.0f);
    }

    public virtual void Launch()
    {
        Vector2 lunchPos;
        Vector2 goPos;
        goPos = transform.position;
        lunchPos = goPos + new Vector2(0, 2f);
        transform.position = Vector2.MoveTowards(transform.position, lunchPos, 2f * Time.deltaTime);
    }

    protected Vector3 GetDir()
    {
        Vector3 dir;
        dir = (target.transform.position - transform.position).normalized;
        return dir;
    }

    protected IEnumerator SelfDisable()
    {
        yield return new WaitForSeconds(selfDestroyTime);
        Destroy(this.gameObject);
    }

    public virtual IEnumerator Movement()
    {
        InvokeRepeating("Launch", 0f, 0.03f);
        yield return new WaitForSeconds(SetTime());
        CancelInvoke();
        InvokeRepeating("MoveTowardTarget", 0f, 0.03f);
    }

    float SetTime()
    {
        return setTime * setRate;
    }
}
