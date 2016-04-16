using UnityEngine;
using System.Collections;

public class ItemClear : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Item>().itemName = "Clear Screen";
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.ClearScreen();
            Destroy(gameObject);
        }
    }
}
