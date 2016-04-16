using UnityEngine;
using System.Collections;

public class ItemDebuffSize : MonoBehaviour {

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Item>().itemName = "Size Enlarge";
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController PlayerControl = other.GetComponent<PlayerController>();  
            PlayerControl.DebuffSizeTime = Time.time;
            PlayerControl.dbsize = true;
            PlayerControl.DebuffSize();
            Destroy(gameObject);
        }
    }
}
