﻿using UnityEngine;
using System.Collections;

public class ItemDebuffSize : MonoBehaviour {

    public PlayerController PlayerControl;

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
            gameObject.SetActive(false);
            //PlayerControl.size -= 5;
            Time DebuffTime = Time.time;
            PlayerControl.DebuffSize(DebuffTime);
        }
    }
}
