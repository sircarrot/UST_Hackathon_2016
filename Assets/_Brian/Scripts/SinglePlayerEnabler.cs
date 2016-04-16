using UnityEngine;
using System.Collections;

public class SinglePlayerEnabler : MonoBehaviour {

    void Start()
    {
        if (!Pass.isMultiplayer)
        {
            MyNetworkManager.instance.CreateGame();
        }
    }
}
