using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private GameLevel level;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.LogError("game manager instance already exist");
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        level = gameObject.AddComponent<InfiniteLevel>();
        level.holder = this;
        level.StartGameLevel();
    }

    public void StopGame()
    {
        RemoveLevel();
    }

    void RemoveLevel()
    {
        if (level)
        {
            level.StopGameLevel();
            Destroy(level.gameObject);
            level = null;
        }
    }

    void OnDestroy()
    {
        instance = null;
        RemoveLevel();
    }
}
