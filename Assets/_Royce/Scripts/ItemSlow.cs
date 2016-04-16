﻿using UnityEngine;
using System.Collections;

public class ItemSlow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Item>().itemName = "Slow Enemy";
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.Slow(5);
            Destroy(gameObject);
        }
    }
}
