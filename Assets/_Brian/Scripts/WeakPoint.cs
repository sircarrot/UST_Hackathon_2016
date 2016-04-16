using UnityEngine;
using System.Collections;

public class WeakPoint : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("weak point");
            UFOBoss boss = GetComponentInParent<UFOBoss>();
            boss.getHit();
        }
    }
}
