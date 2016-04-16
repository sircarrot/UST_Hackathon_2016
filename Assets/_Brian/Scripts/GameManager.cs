using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public static float enemySpeedScale = 1f;

    static float freezeTimer = -1f;
    static float slowTimer = -1f;

    public GameObject gameSceneMenu;
    public GameObject gamePauseMenu;
    public GameObject gameOverMenu;

    public Text timeText;

    public AudioClip gameOverClip;

    private GameLevel level;
    AudioSource player;

    public float timer;
    bool isRunning;

    
    public void PauseGame()
    {
        Time.timeScale = 0f;
        gamePauseMenu.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        gamePauseMenu.SetActive(false);
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
        player = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!isRunning)
            return;
        System.TimeSpan t = System.TimeSpan.FromSeconds(timer);

        if (timer > 3600)
        {
            timeText.text = string.Format("{0:D2}h:{1:D2}:{2:D2}",
                        t.Hours,
                        t.Minutes,
                        t.Seconds);
        }
        else
        {
            timeText.text = string.Format("{0:D2}:{1:D2}",
                        t.Minutes,
                        t.Seconds);
        }
    }

    public void LeaveGame()
    {
        SceneManager.LoadScene(MenuNavigation.MENU);
    }

    public void StartGame()
    {
        StopGame();
        ClearScreen();
        level = gameObject.AddComponent<InfiniteLevel>();
        level.holder = this;
        level.StartGameLevel();
        timer = 0;
        gameOverMenu.SetActive(false);
        isRunning = true;
    }

    public void GameOver()
    {
        if (!isRunning) return;
        StopGame();
        gameOverMenu.SetActive(true);
        player.clip = gameOverClip;
        player.Play();
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
        isRunning = false;
        RemoveLevel();
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

    public void Freeze(float duration)
    {
        if (freezeTimer < duration) freezeTimer = duration;
    }
    public void Slow(float duration)
    {
        if (slowTimer < duration) slowTimer = duration;
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (freezeTimer > 0)
        {
            enemySpeedScale = 0f;
        }
        else if (slowTimer > 0)
        {
            enemySpeedScale = 0.5f;
        }
        freezeTimer -= Time.deltaTime;
        slowTimer -= Time.deltaTime;
    }
}
