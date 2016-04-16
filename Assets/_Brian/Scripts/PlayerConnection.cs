using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerConnection : NetworkBehaviour {

	// Use this for initialization
	void Awake () {
        
	}

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        CmdConnected();
    }

    void Start()
    {
        
    }

	// Update is called once per frame
	void Update () {
	
	}

    void OnDestory()
    {
        CmdDisconnected();
    }

    [Command]
    public void CmdConnected()
    {
        MyNetworkManager.instance.OnPlayerObjectConnected(gameObject);
    }

    [Command]
    public void CmdDisconnected()
    {
        MyNetworkManager.instance.OnPlayerObjectDisconnected(gameObject);
    }

}
