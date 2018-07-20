using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootMovement : MonoBehaviour {
    public enum LootType{
        power,
        gold
    }
    float speed;
    public LootType lType;
    private void Start()
    {
        speed = -1f;
    }
    
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 target;
        Vector3 pos;
        pos = transform.position;
        target = pos - new Vector3(-1,0,0);
        transform.position = Vector3.MoveTowards(transform.position,target,speed*Time.deltaTime);
    }


    void Promote(GameObject go)
    {
        switch (lType)
        {
            case LootType.power:
                go.SendMessage("PowerUpCounter");
                break;
            case LootType.gold:
                go.SendMessage("GoldUP");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Promote(collision.transform.gameObject);
            Destroy(this.gameObject);
        }
    }
}
