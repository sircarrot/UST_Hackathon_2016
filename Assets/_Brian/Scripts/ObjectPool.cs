using UnityEngine;
using UnityEngine.Networking;

public class ObjectPool : NetworkBehaviour
{

    public GameObject normalRock;
    public GameObject bouncingRock;

    void Start()
    {
        ClientScene.RegisterPrefab(normalRock);
        ClientScene.RegisterPrefab(bouncingRock);
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