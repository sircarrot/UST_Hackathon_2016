using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class EnemyObject : NetworkBehaviour {

    public bool isBoss = false;

    void Update()
    {
        //this.transform.rotation = direction;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController controller = other.GetComponent<PlayerController>();
            controller.GetHit();
            Destroy(gameObject);
        }
    }
}
