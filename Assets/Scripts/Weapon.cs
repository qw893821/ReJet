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

    //weapon's target pos
    public GameObject target;
}
