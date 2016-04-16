using UnityEngine;
using System.Collections;

public class ItemDebuffQuake : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Item>().itemName = "Quake Debuff";
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Quake
            Destroy(gameObject);
        }
    }
}
