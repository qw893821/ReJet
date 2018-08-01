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

    private void Start()
    {
        player = GameObject.Find("Player") ;
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
        if (idleTimer >= idleTime)
        {
            isidle = false;
            idleTimer = 0;
        }
    }
    
    void Drill()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetPos, drillSpeed * Time.deltaTime);
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
            drillSpeed = Vector3.Distance(transform.position,targetPos)/attackTime;
        }
        else
        {
            Drill();
        }
    }
}
