﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour {

    public float speed; 
    public float size;

    public float normspeed; // Normal value
    public float normsize; // Normal value

    public float dbspeedval; //Debuff value
    public float dbsizeval; // Debuff value

    public float dbfrzval; // For testing freeze values

    public bool invincible; // Invincible
    public bool inverse; //Debuff Inverse
    public bool dbfreeze; //Debuff Freeze
    public bool shield; // Shield
    public bool dbspeed; // Debuff Slow
    public bool dbsize; // Debuff Size

    // Buff/Debuff Times
    public float DebuffSlowTime;
    public float DebuffSizeTime;
    public float DebuffInverseTime;
    public float DebuffFreezeTime;
    public float BuffInvincibleTime;
    public float BuffFreezeTime;
    public float BuffSlowTime;
    //No Shield, Clear, Quake

    private float debufftime;
    private float bufftime;

    public Vector3 lookdir;

    private AudioSource audioPlayer;
    public AudioClip pickupSound;

    public GameObject shieldObject;
    public GameObject invicibilityObject;

    public Sprite localPlayerSprite;
    //private Rigidbody2D PlayerCharacter;

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        //PlayerCharacter = GetComponent<Rigidbody2D>();
        ResetBuffDebuff();

        speed = 10;
        size = 0.2f;

        normspeed = 5;
        normsize = 0.2f;

        dbspeedval = 2;
        dbsizeval = 0.4f;


        dbfrzval = speed;
        DebuffSlowTime = 0;
        DebuffSizeTime = 0;
        DebuffInverseTime = 0;
        DebuffFreezeTime = 0;
        BuffInvincibleTime = 0;
        BuffFreezeTime = 0;
        BuffSlowTime = 0;

        debufftime = 5;
        bufftime = 5;

        lookdir = new Vector3 (0, 0, 0);
        //
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = localPlayerSprite;
    }

    public void ItemPickedUp(Item item)
    {
        audioPlayer.clip = pickupSound;
        audioPlayer.Play();
        GameManager.instance.DisplayPickupItem(item.itemName);
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;

        if (GameManager.instance.timer <= 0.5)
        {
            transform.position = new Vector3(0, 0, 0);
            lookdir = new Vector3(0,0,0);
        }


        float moveHorizontal = Input.GetAxis("Horizontal") + (Input.acceleration.x * 2.5f);
        float moveVertical = Input.GetAxis("Vertical") + (Input.acceleration.y * 2.5f);
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        //Items
        //Debuffs
        if (dbspeed) DebuffSlow();
        if (dbsize) DebuffSize();
        if (dbfreeze) DebuffFreeze();

        if (inverse)
        {
            DebuffInverse();
            transform.position -= movement * Time.deltaTime * speed;
        }
        else
        {
            transform.position += movement * Time.deltaTime * speed;
        }
        //Buffs
        if (invincible) BuffInvincible();

        if (movement.magnitude>0.1) { lookdir = movement; }
        if(lookdir != Vector3.zero)
        {
            var newRotation = Quaternion.LookRotation(-lookdir, Vector3.forward);
            newRotation.x = 0.0f;
            newRotation.y = 0.0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
        }
        
    }

    public void DebuffSlow()
    {
        speed = dbspeedval;
        float diff = Time.time - DebuffSlowTime;
        if(diff >= debufftime)
        {
            dbspeed = false;
            speed = normspeed;
        }
    }
    public void DebuffSize()
    {
        size = dbsizeval;
        transform.localScale = new Vector3(size, size, 1);
        float diff = Time.time - DebuffSizeTime;
        if (diff >= debufftime/2)
        {
            dbsize = false;
            size = normsize;
            transform.localScale = new Vector3(size, size, 1);
        }
    }
    public void DebuffFreeze()
    {
        speed = 0;       
        float diff = Time.time - DebuffFreezeTime;
        if (diff >= (debufftime/2))
        {
            dbfreeze = false;
            speed += dbfrzval;
        }
    }
    public void DebuffInverse()
    {
        float diff = Time.time - DebuffInverseTime;
        if (diff >= debufftime)
        {
            inverse = false;
        }
    }
    public void BuffInvincible()
    {
        float diff = Time.time - BuffInvincibleTime;
        if (diff >= bufftime)
        {
            invincible = false;
            invicibilityObject.SetActive(false);
        }
    }

    public void GetHit()
    {
        if (!invincible) {
            if (!shield) { CmdCauseGameOver(); } else { shield = false; shieldObject.SetActive(false); } }
    }
    [Command]
    void CmdCauseGameOver()
    {
        shieldObject.SetActive(false);
        ResetBuffDebuff();
        GameManager.instance.GameOver();
    }

    void ResetBuffDebuff()
    {
        invincible = false;
        inverse = false;
        dbfreeze = false;
        shield = false;
        dbsize = false;
        dbspeed = false;
    }
}
    