using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    float timer;

	// Use this for initialization
	void Start () {
        timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.time - timer >= 10)
        {
            Destroy(gameObject);
        }
	}
}
