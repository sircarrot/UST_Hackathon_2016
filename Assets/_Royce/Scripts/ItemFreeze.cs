using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ItemFreeze : NetworkBehaviour
{

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
            
            Destroy(gameObject);
        }
    }

    [Command]
    void CmdItemTakeEffect()
    {
        GameManager.instance.Freeze(3);
    }
}
