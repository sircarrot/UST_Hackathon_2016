using UnityEngine;
using System.Collections;

public class ShipMove : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.LeftArrow))
			transform.Rotate (Vector3.forward * 90 * Time.deltaTime);
		else if(Input.GetKey(KeyCode.RightArrow))
			transform.Rotate (Vector3.forward * -90 * Time.deltaTime);


	}
}
