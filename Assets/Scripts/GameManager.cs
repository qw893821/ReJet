using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager _gm;
    public static GameManager gm
    {
        get { return _gm; }
    }

    
    public List<BulletGarbge> bullets;

    public struct GarbgeCheck
    {
        public bool isCreated;
        public int garbgeIndex;
        
    }
    GarbgeCheck gc;
    // Use this for initialization
    void Start () {
        if (!_gm)
        {
            _gm = this;
        }
        bullets = new List<BulletGarbge>();

        gc = new GarbgeCheck();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(bullets.Count);
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

}
