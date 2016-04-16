using UnityEngine;
using System.Collections;

public class ItemFreeze : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Item>().itemName = "Freeze Enemy";
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.Freeze(3);
            Destroy(gameObject);
        }
    }
}
