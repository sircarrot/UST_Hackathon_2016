﻿using UnityEngine;
using System.Collections;

public class ItemShield: MonoBehaviour {

    public PlayerController PlayerControl;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Item>().itemName = "Shield";
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController PlayerControl = other.GetComponent<PlayerController>();
            PlayerControl.shield = true;
            PlayerControl.shieldObject.SetActive(true);
            //Shield Function
            Destroy(gameObject);
        }
    }
}
