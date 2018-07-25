using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explision : MonoBehaviour {
    public Sprite vuln;
    public Sprite invuln;
    SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        sr = transform.GetComponent<SpriteRenderer>();
	}
	void Awake()
    {
        StartCoroutine(SelfDestroyer(0.5f));
    }
	// Update is called once per frame
	void Update () {
    }

    IEnumerator SelfDestroyer(float time)
    {
        Destroy(this.transform.gameObject, time);
        yield return null;
    }

    void ChangeSprite(string vulnType)
    {
        if (vulnType == "vuln") {
            sr.sprite = vuln;
        }
        else
        {
            sr.sprite = invuln;
        }
    }
}
