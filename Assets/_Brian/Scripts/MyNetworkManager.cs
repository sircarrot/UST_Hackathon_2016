using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class MyNetworkManager : NetworkManager {

    public static MyNetworkManager instance;

    List<GameObject> players;

    [HideInInspector]
    public bool isHost;

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
    }
}