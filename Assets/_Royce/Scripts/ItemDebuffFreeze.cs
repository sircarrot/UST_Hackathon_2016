using UnityEngine;
using System.Collections;

public class ItemDebuffFreeze : MonoBehaviour {

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
            PlayerController PlayerControl = other.GetComponent<PlayerController>();
            PlayerControl.DebuffFreezeTime = Time.time;
            PlayerControl.dbfreeze = true;
            PlayerControl.DebuffFreeze();
            Destroy(gameObject);
        }
    }
}
