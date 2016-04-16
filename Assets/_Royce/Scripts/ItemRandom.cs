using UnityEngine;
using System.Collections;

public class ItemRandom : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int luck = Random.Range(0,100);
        
        if (luck < 30)
        {
            //Debuff
            int rng = Random.Range(0, 5);
            switch (rng) {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
        else if (luck < 70)
        {
            //Normal
            int rng = Random.Range(0, 3);
            switch (rng)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
        else
        {
            //OP items
            int rng = Random.Range(0, 2);
            switch (rng)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }
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
