using UnityEngine;
using System.Collections;

public class MovementBehaviour : MonoBehaviour {

    public enum MovementType
    {
        Bullet
    }

    public MovementType type = MovementType.Bullet;
    public float speed = 1;
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += transform.up * speed * GameManager.enemySpeedScale * Time.deltaTime;
    }
}
