using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;

public class MyNetworkManager : NetworkManager {

    public static MyNetworkManager instance;
    
    public GameObject multiplayerCanvas;
    public GameObject startGameCanvas;
    public GameObject gamePlane;

    public InputField addressInput;

    public bool isMultiplayer;
    public bool debugForMultiplayer;

    List<GameObject> players;

    [HideInInspector]
    public bool isHost;
    public bool isMatchStarted = false;

    public void saveAddress()
    {
        PlayerPrefs.SetString("ipaddress", networkAddress);
    }

    void Start()
    {
        networkAddress = PlayerPrefs.GetString("ipaddress", "localhost");
        addressInput.text = networkAddress;

        if (isMultiplayer = (debugForMultiplayer || Pass.isMultiplayer))
        {
            multiplayerCanvas.SetActive(true);
        }
        else
        {
            multiplayerCanvas.SetActive(false);
            CreateGame();
        }
    }

    public void StartNewGame()
    {
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
        if (!isMultiplayer)
        {
            StartNewGame();
        }
        else
        {
            startGameCanvas.SetActive(true);
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
        multiplayerCanvas.SetActive(false);
        gamePlane.SetActive(true);
    }

    public void JoinGame()
    {
        isHost = false;
        StartClient();
        multiplayerCanvas.SetActive(false);
        saveAddress();
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

    public override void OnStopClient()
    {
        base.OnStopClient();
        multiplayerCanvas.SetActive(true);
    }
    void OnDestroy()
    {
        StopMultiplayer();
    }
}