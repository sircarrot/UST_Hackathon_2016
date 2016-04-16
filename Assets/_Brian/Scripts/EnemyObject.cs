﻿using UnityEngine;
using System.Collections;

public class EnemyObject : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController controller = other.GetComponent<PlayerController>();
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
    }
}
