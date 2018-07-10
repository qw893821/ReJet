using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public GameObject bullet;
    float healthPoint;
    public float lastingtime;
    // Use this for initialization
   
    private void Awake()
    {
        InvokeRepeating("InstBullet",1f,2f);
        Invoke("CancelInvoke",lastingtime);
    }
    // Update is called once per frame
    void Update()
    {

    }

    void ApplyDamage(float ap)
    {
        healthPoint -= ap;
        Die();
    }


    void Die()
    {
        if (healthPoint <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void InstBullet()
    {
        GameObject bullet_Clone;
        bullet_Clone=Instantiate(bullet,transform.position,Quaternion.identity);
        bullet_Clone.GetComponent<EnemyBullet>().SetProperity();
    }
        
}
