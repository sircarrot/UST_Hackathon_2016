using UnityEngine;
using System.Collections;

public class ItemRandom : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int luck = Random.Range(0,10);
        
        if (luck < 3)
        {
            //Debuff
            int rng = Random.Range(0, 4);
            switch (rng) {
                case 0:
                    gameObject.AddComponent<ItemDebuffFreeze>();
                    break;
                case 1:
                    gameObject.AddComponent<ItemDebuffInverse>();
                    break;
                case 2:
                    gameObject.AddComponent<ItemDebuffSlow>();
                    break;
                case 3:
                    gameObject.AddComponent<ItemDebuffSize>();
                    break;
                //case 4:
                //    gameObject.AddComponent<ItemDebuffQuake>();
                //    break;
            }
        }
        else if (luck < 7)
        {
            //Normal
            int rng = Random.Range(0, 3);
            switch (rng)
            {
                case 0:
                    gameObject.AddComponent<ItemFreeze>();
                    break;
                case 1:
                    gameObject.AddComponent<ItemShield>();
                    break;
                case 2:
                    gameObject.AddComponent<ItemSlow>();
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
                    gameObject.AddComponent<ItemClear>();
                    break;
                case 1:
                    gameObject.AddComponent<ItemInvicible>();
                    break;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
