using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    //public Text countText;
    //public Text winText;

    private Rigidbody2D PlayerCharacter;
    //private int count;

    void Start()
    {
        PlayerCharacter = GetComponent<Rigidbody2D>();
        //count = 0;
        //winText.text = "";
        //SetCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        PlayerCharacter.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            switch (other.gameObject.name)
            {
                case "Freeze":
                    break;
                case "Slow":
                    break;
                case "Shield":
                    break;
                case "Invincible":
                    break;
                case "ClearScreen":
                    break;
                case "DebuffSlow":
                    break;
                case "DebuffInverse":
                    break;
                case "DebuffFreeze":
                    break;
                case "DebuffSize":
                    break;
                case "DebuffQuake":
                    break;
            } 
            
            //Item effects
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Dead

        }

    }
}
