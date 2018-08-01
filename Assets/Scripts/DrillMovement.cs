using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillMovement : MonoBehaviour {

    public float drillSpeed;
    public float idleTime;
    float idleTimer;
    public float attackTime;
    //float attackTimer;
    bool isidle;
    GameObject player;
    Vector3 targetPos;
    LineRenderer lr;
    private void Start()
    {
        player = GameObject.Find("Player") ;
        lr = transform.GetComponent<LineRenderer>();
        isidle = true;
    }

    private void Update()
    {
        Action();
    }

    //when idle, drill monster track player position
    void Idling()
    {
        idleTimer += Time.deltaTime;
        targetPos = player.transform.position;
        targetPos -= (targetPos - transform.position).normalized;
        if (idleTimer >= idleTime)
        {
            isidle = false;
            idleTimer = 0;
        }
    }
    
    void Drill()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetPos, drillSpeed * Time.deltaTime);
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1,targetPos);
        if (transform.position == targetPos)
        {
            
            isidle = true;
        }
    }

    void Action()
    {

        if (isidle)
        {
            Idling();
            transform.rotation = Quaternion.LookRotation(transform.forward,transform.position-targetPos);
            transform.rotation *= Quaternion.Euler(0,0,90.0f);
            drillSpeed = Vector3.Distance(transform.position,targetPos)/attackTime;
        }
        else
        {
            Drill();
        }
    }
}
