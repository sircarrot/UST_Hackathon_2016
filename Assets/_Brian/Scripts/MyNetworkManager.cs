using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class MyNetworkManager : NetworkManager {

    public static MyNetworkManager instance;

    public GameObject gameManagerPrefab;

    List<GameObject> players;

    [HideInInspector]
    public bool isHost;
    public bool isMatchStarted = false;

    public void StartNewGame()
    {
        GameObject gameManagerObject = Instantiate(gameManagerPrefab);
        GameManager.instance.StartGame();
        isMatchStarted = true;
    }

    public void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void OnPlayerObjectConnected(GameObject player)
    {
        players.Add(player);
        print("player connected");
        if (!Pass.isMultiplayer)
        {
            StartNewGame();
        }
    }

    public void OnPlayerObjectDisconnected(GameObject player)
    {
        players.Remove(player);
        print("player disconnected");
    }
    
    public void CreateGame()
    {
        isHost = true;
        StartHost();
        players = new List<GameObject>();
    }
    public void JoinGame()
    {
        isHost = false;
        StartClient();
    }
    public void StopMultiplayer()
    {
        if (isHost)
            StopHost();
        else
            StopClient();
        isHost = false;
        players = null;
        isMatchStarted = false;
    }
}