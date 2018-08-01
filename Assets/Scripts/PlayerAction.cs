using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {
    float speed;
    float maxSpeed;
    float speedUPRate;
    //shield
    GameObject shield;
    float maxShieldENE;
    float basicshiedlENE;
    float seReductionRate;
    public float shieldENE;
    float shieldMod;
    float seRengenerateRate;
    bool shieldOverheat;

    public GameObject jetBody;
    public Sprite flight_default, flight_up, flight_down;
    SpriteRenderer playerSR;
	// Use this for initialization
	void Start () {
        speed = 0f;
        maxSpeed = 5.0f;
        speedUPRate = 15.0f;
        playerSR=transform.GetComponent<SpriteRenderer>();
        shield = GameObject.Find("Shield");
        basicshiedlENE = 20.0f;
        maxShieldENE = 20.0f;
        shieldMod = 1.0f;
        shieldENE = basicshiedlENE * shieldMod;
        seReductionRate = 1.0f;
        //negative value
        seRengenerateRate = -1.0f;
        shieldOverheat = false;
	}
	
	// Update is called once per frame
	void Update () {
        float hori, vert;
        hori = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
        Move(hori, vert);
        ShieldUP();
	}

    void Move(float x,float y)
    {
        Vector2 pos;
        Vector2 target;
        MoveDirectionInput(x,y);
        pos = transform.position;
        target = pos+ new Vector2(x,y).normalized;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        MovingAnimation(y);
    }

    void MoveDirectionInput(float x, float y)
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            speed = SpeedUP(speed);
        }
        else
        {
            speed = 0f;
        }
    }

    float SpeedUP(float s)
    {
        if (s <= maxSpeed)
        {
            s += speedUPRate*Time.deltaTime ;
        }
        else
        {
            s = maxSpeed;
        }
        return s;
    }

    void MovingAnimation(float y)
    {
        if (y > 0)
        {
            jetBody.transform.eulerAngles = new Vector3(Mathf.Lerp(0,45.0f,speed/maxSpeed),0f,0f);
        }
        else if (y < 0)
        {
            jetBody.transform.eulerAngles = new Vector3(Mathf.Lerp(0f,-45.0f,speed/maxSpeed),0f,0f);
        }
        else { jetBody.transform.eulerAngles = new Vector3(0,0,0); }
    }

    void ShieldUP()
    {
        if (Input.GetKey("k")&&ShieldENEChenck()&&!shieldOverheat)
        {
            shield.SetActive(true);
            ShieldENEReduction(seReductionRate);
        }
        else { shield.SetActive(false);
            ShieldENEReduction(seRengenerateRate);
        }
    }

    bool ShieldENEChenck()
    {
        if (shieldENE > 0)
        {
            return true;
        }
        else return false;
    }

    void ShieldENEReduction(float ene)
    {
        if (shieldENE >=0&& shieldENE <= maxShieldENE) {
            shieldENE -= ene * Time.deltaTime;
        }
        else if(shieldENE > maxShieldENE)
        {
            shieldENE = maxShieldENE;
            shieldOverheat = false;
        }
        else { shieldENE = 0;
            shieldOverheat = true;
        }

    }

    void Damaged(float dmg)
    {
        if (shield.activeSelf)
        {
            shieldENE-=dmg;
            Debug.Log("hit shield");
        }
        else
        {
            Debug.Log("hit player");
        }
    }
}
