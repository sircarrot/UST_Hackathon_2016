﻿using UnityEngine;
using System.Collections;

public class ItemDebuffSlow : MonoBehaviour {

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
            //PlayerControl.speed -= 3;
            Time DebuffTime = Time.time;
            PlayerControl.DebuffSpeed(DebuffTime);
        }
    }
}
