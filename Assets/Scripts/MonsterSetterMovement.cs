using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSetterMovement : MonoBehaviour {
    Vector3 target;
    GameObject player;
    Monsters monster;
    bool move;
    bool back;
    public float setTime;
	// Use this for initialization
	void Start () {
        player = GameManager.gm.player;
        monster = transform.GetComponent<Monsters>();
        move = true;
        back = false;
	}
	
	// Update is called once per frame
	void Update () {
        target = player.transform.position;
        Action();

	}

    void LinearMove()
    {
        float speed;
        Vector3 pos;
        pos = transform.position;
        target.x = 3;
        if (setTime >0) {
            setTime -= Time.deltaTime;
        }
        if (setTime <= 0)
        {
            move = false;
        }
        else { 
            //make sure time is not bigger than 3.0f
            speed = (Vector3.Distance(target, pos) / setTime >= 3.0f ? 3.0f : Vector3.Distance(target, pos) / setTime);
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }

    void Action()
    {
        if (move&&!back)
        {
            LinearMove();
        }
        else if(!move&&!back)
        {
            //set bullet    
            Inst();
        }
        else { Retreat(); }
    }

    void Inst()
    {
        Instantiate(monster.bullet, transform.position, transform.rotation);
        back = true;
    }

    void Retreat()
    {
        var speed = 3.0f;
        Vector3 target;
        Vector3 pos;
        pos = transform.position;
        target = pos;
        target.y = 5.6f;
        transform.position = Vector3.MoveTowards(transform.position,target,speed*Time.deltaTime);
    }
}
