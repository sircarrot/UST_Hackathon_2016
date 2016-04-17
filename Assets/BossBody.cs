using UnityEngine;
using System.Collections;

public class BossBody : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController controller = other.GetComponent<PlayerController>();
            controller.GetHit();
        }
    }
}
