using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubWeapon : Bullet {

    void Start()
    {
        StartCoroutine(SelfDisable());
    }

    private void Awake()
    {
        dir = transform.right;
    }
    // Update is called once per frame
    void Update()
    {
        Move();

    }

    private void Move()
    {
        Vector3 target;
        target = transform.position + dir;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletHit(collision);
    }

    
}
