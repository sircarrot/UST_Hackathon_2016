using UnityEngine;
using System.Collections;

public class ObjectBondary : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnemyObject>())
        {
            Destroy(other.gameObject);
        }
    }
}
