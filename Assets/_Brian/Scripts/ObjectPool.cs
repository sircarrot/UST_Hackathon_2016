using UnityEngine;
using UnityEngine.Networking;

public class ObjectPool : NetworkBehaviour
{
    //Rocks
    public GameObject normalRock;
    public GameObject bouncingRock;

    //Items
    public GameObject BuffInvincible;
    public GameObject BuffFreeze;
    public GameObject BuffSlow;
    public GameObject BuffClear;
    public GameObject BuffShield;

    public GameObject RandomItem;

    public GameObject DebuffFreeze;
    public GameObject DebuffInverse;
    public GameObject DebuffSize;
    public GameObject DebuffSlow;
    public GameObject DebuffQuake;


    void Start()
    {
        ClientScene.RegisterPrefab(normalRock);
        ClientScene.RegisterPrefab(bouncingRock);

        ClientScene.RegisterPrefab(BuffInvincible);
        ClientScene.RegisterPrefab(BuffFreeze);
        ClientScene.RegisterPrefab(BuffSlow);
        ClientScene.RegisterPrefab(BuffShield);
        ClientScene.RegisterPrefab(BuffClear);

        ClientScene.RegisterPrefab(RandomItem);

        ClientScene.RegisterPrefab(DebuffFreeze);
        ClientScene.RegisterPrefab(DebuffInverse);
        ClientScene.RegisterPrefab(DebuffSize);
        ClientScene.RegisterPrefab(DebuffSlow);
        ClientScene.RegisterPrefab(DebuffQuake);

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