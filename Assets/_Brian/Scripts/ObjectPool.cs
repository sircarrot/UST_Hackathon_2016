using UnityEngine;

public class ObjectPool : MonoBehaviour
{
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

    public GameObject normalRock;
    public GameObject bouncingRock;
}