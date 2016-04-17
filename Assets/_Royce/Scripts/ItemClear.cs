using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ItemClear : NetworkBehaviour {

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
            CmdItemTakeEffect();
            Destroy(gameObject);
        }
    }

    [Command]
    void CmdItemTakeEffect()
    {
        GameManager.instance.ClearScreen();
    }
}
