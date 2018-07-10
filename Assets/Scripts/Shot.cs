using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    public GameObject bullet;

    // Update is called once per frame
    void Update () {
        Fire();
    }
    //fire bullet
    void Fire()
    {
        if (Input.GetKey("j"))
        {
            Instantiate(bullet,transform.position,Quaternion.identity);
        }
        
    }
}
