using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public static float enemySpeedScale = 1f;

    static float freezeTimer = -1f;
    static float slowTimer = -1f;

    public GameObject gameSceneMenu;
    public GameObject gamePauseMenu;
    public GameObject gameOverMenu;

    private GameLevel level;

    public void Freeze(float duration)
    {
        if(freezeTimer < duration)freezeTimer = duration;
    }
    public void Slow(float duration)
    {
        if (slowTimer < duration) slowTimer = duration;
    }
    void FixedUpdate()
    {
        if(freezeTimer > 0)
        {
            enemySpeedScale = 0f;
        }else if(slowTimer > 0)
        {
            enemySpeedScale = 0.5f;
        }
        freezeTimer -= Time.deltaTime;
        slowTimer -= Time.deltaTime;
    }

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
    void Update()
    {

    }

    public void StartGame()
    {
        StopGame();
        level = gameObject.AddComponent<InfiniteLevel>();
        level.holder = this;
        level.StartGameLevel();
    }

    public void GameOver()
    {
        StopGame();
        gameOverMenu.SetActive(true);
    }

    //clear all enemy
    public void ClearScreen()
    {
        EnemyObject[] allObjects = FindObjectsOfType<EnemyObject>();
        foreach(EnemyObject obj in allObjects)
        {
            Destroy(obj.gameObject);
        }
    }

    public void StopGame()
    {
        RemoveLevel();
        ClearScreen();
    }

    void RemoveLevel()
    {
        if (level)
        {
            level.StopGameLevel();
            Destroy(level);
            level = null;
        }
    }

    void OnDestroy()
    {
        instance = null;
        RemoveLevel();
    }
}
