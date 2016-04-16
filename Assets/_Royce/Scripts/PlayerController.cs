using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody2D PlayerCharacter;

    void Start()
    {
        PlayerCharacter = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical,0);
        transform.position += movement * Time.deltaTime * speed;

        //Up and down no rotation
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.forward * 90 * Time.deltaTime);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.forward * -90 * Time.deltaTime);
        
    }
}
