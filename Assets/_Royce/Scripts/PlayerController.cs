using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed; // Debuff slow, -3
    public float size; // Debuff size, -5

    public float dbspeedval; //Debuff value
    public float dbsizeval; // Debuff value
    public float dbfrzval; // For testing freeze values

    public bool invincible; // Invincible
    public bool inverse; //Debuff Inverse
    public bool dbfreeze; //Debuff Freeze
    public bool shield; // Shield
    public bool dbspeed; // Debuff Slow
    public bool dbsize; // Debuff Size

    public bool tempbool; // Checks for first instances of debuffs

    // Buff/Debuff Times
    public float DebuffSlowTime;
    public float DebuffSizeTime;
    public float DebuffInverse;
    public float DebuffFreezeTime;
    public float BuffInvincibleTime;
    public float BuffFreezeTime;
    public float BuffSlowTime;
    //No Shield, Clear, Quake

    private float debufftime;
    private float bufftime;

    //private Rigidbody2D PlayerCharacter;

    void Start()
    {
        //PlayerCharacter = GetComponent<Rigidbody2D>();
        invincible = false;
        inverse = false;
        dbfreeze = false;
        shield = false;
        dbsize = false;
        dbspeed = false;

        dbfrzval = speed;
        DebuffSlowTime = 0;
        DebuffSizeTime = 0;
        DebuffInverse = 0;
        DebuffFreezeTime = 0;
        BuffInvincibleTime = 0;
        BuffFreezeTime = 0;
        BuffSlowTime = 0;

        debufftime = 5;
        bufftime = 5;
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

        //Items
        //Debuffs
        if (dbspeed) DebuffSlow();
        if (dbsize) DebuffSize();
        if (dbfreeze) DebuffFreeze();
        
        //Buffs
        if (invincible) BuffInvincible();

        
    }

    public void DebuffSlow()
    {
        if (!tempbool) { speed -= dbspeedval; tempbool = true; }

        float diff = Time.time - DebuffSlowTime;
        if(diff >= debufftime)
        {
            dbspeed = false;
            speed += dbspeedval;
        }
    }
    public void DebuffSize()
    {
        if (!tempbool) { size -= dbsizeval; tempbool = true; }
        float diff = Time.time - DebuffSizeTime;
        if (diff >= debufftime)
        {
            dbsize = false;
            size += dbsizeval;
        }
    }
    public void DebuffFreeze()
    {
        if (!tempbool) { speed = 0; tempbool = true;}        

        float diff = Time.time - DebuffFreezeTime;
        if (diff >= debufftime)
        {
            dbfreeze = false;
            speed += dbfrzval;
        }
    }
    public void BuffInvincible()
    {
        float diff = Time.time - BuffInvincibleTime;
        if (diff >= bufftime)
        {
            invincible = false;
        }
    }
}
