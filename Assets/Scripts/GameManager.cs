using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
    private static GameManager _gm;
    public static GameManager gm
    {
        get { return _gm; }
    }

    //public List<BulletGarbge> bullets;

    public struct GarbgeCheck
    {
        public bool isCreated;
        public int garbgeIndex;

    }

    private int _lifepoint;
    private int lifePoint
    {
        get { return _lifepoint; }
        set { _lifepoint = value; }

    }

    GarbgeCheck gc;
    public GameObject explision_Anim;

    public GameObject explosionSoundEffect;

    public GameObject player;
    public Shot shot;
    public GameObject boundary1, boundary2;
    // loot go
    public GameObject power_Loot;

    // Use this for initialization
    void Awake () {
        if (!_gm)
        {
            _gm = this;
        }
        else
        { Destroy(this); }
        //bullets = new List<BulletGarbge>();
        player = GameObject.Find("Player");
        shot = player.GetComponent<Shot>();
        gc = new GarbgeCheck();
        InvokeRepeating("MoveBoundary",0.5f,0.1f);

        //test
        lifePoint = 100;
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    private void LateUpdate()
    {
        gc.isCreated = false;
    }

    public GarbgeCheck GarbageFind(List<BulletGarbge> bullets,GameObject go,string name)
    {
        
        for(int i = 0; i < bullets.Count; i++)
        {
            
            if (bullets[i].bulletName == go.name)
            {
                gc.isCreated = true;
                gc.garbgeIndex = i;
            }
            else
            {
                gc.isCreated = false;
                
            }
        }
        return gc;
    }

    public string NameReplace(GameObject go)
    {
        string name;
        name = go.name;
        List<char> chars = new List<char>();
        chars.AddRange(name);
        chars.RemoveRange(chars.Count - 7, 7);
        name = new string(chars.ToArray());
        return name;
    }

    public void DestroyerCounter(GameObject go,float time)
    {

        StartCoroutine(Destroyer(go,time));
    }

    IEnumerator Destroyer(GameObject go,float time)
    {
        Destroy(go,time);
        yield return null;
    }

    IEnumerator BoundaryShifter(GameObject go)
    {
        if (go.transform.position.x <= -17.0f)
        {
            go.transform.Translate(new Vector3(17.0f,0,0));
        }
        else {//x -18 to make sure boundary will move more than -17f
            go.transform.position = Vector3.MoveTowards(go.transform.position,new Vector3(-18.0f, 0, 0),1f*Time.deltaTime);
        }
        yield return /*new WaitForSeconds(0.1f);*/null;
    }

    void MoveBoundary()
    {
        StartCoroutine(BoundaryShifter(boundary1));
        StartCoroutine(BoundaryShifter(boundary2));
    }

    public void SwpawnPlayer()
    {
        if (LifeLeftCheck())
        {
            var spawnPos = new Vector3(-8.5f,0,0);

            player.transform.position = spawnPos;
            player.GetComponent<PlayerAction>().RestoreShield();
        }
        else
        {
            //game over

        }
    }

    bool LifeLeftCheck()
    {
        if (lifePoint >= 1)
        {
            lifePoint--;
            return true;
        }
        return false;
    }
}
