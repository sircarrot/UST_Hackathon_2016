using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed; // Debuff slow, -3
    public float size; // Debuff size, -5

    public bool invincible; // Invincible
    public bool inverse; //Debuff Inverse
    public bool dbfreeze; //Debuff Freeze
    public bool shield; // Shield

    public float DebuffSlowTime;
    public float DebuffSizeTime;
    public float DebuffInverse;
    public float DebuffFreezeTime;
    public float BuffInvincibleTime;

    private Rigidbody2D PlayerCharacter;

    void Start()
    {
        PlayerCharacter = GetComponent<Rigidbody2D>();
        invincible = false;
        inverse = false;
        dbfreeze = false;
        shield = false;

        //
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

    public void DebuffSlow()
    {
        float diff = Time.time - DebuffSlowTime;
    }

    public void DebuffSize()
    {

    }
}
