using UnityEngine;
using UnityEngine.Networking;

public class ObjectPool : NetworkBehaviour
{
    //Rocks
    public GameObject normalRock;
    public GameObject bouncingRock;

    //Items
    public GameObject BuffInvincible;

    public GameObject DebuffFreeze;
    public GameObject DebuffInverse;
    public GameObject DebuffSize;
    public GameObject DebuffSlow;


    void Start()
    {
        ClientScene.RegisterPrefab(normalRock);
        ClientScene.RegisterPrefab(bouncingRock);

        ClientScene.RegisterPrefab(BuffInvincible);

        ClientScene.RegisterPrefab(DebuffFreeze);
        ClientScene.RegisterPrefab(DebuffInverse);
        ClientScene.RegisterPrefab(DebuffSize);
        ClientScene.RegisterPrefab(DebuffSlow);
    }

    public static ObjectPool instance;
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.LogError("ObjectPool instance already exist");
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        instance = null;
    }

}