using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    float timer;
    public string itemName;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().ItemPickedUp(this);
        }
    }
}
