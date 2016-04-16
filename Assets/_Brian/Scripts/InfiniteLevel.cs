using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InfiniteLevel : GameLevel
{
    public override void clearAllObjects()
    {
    }

    public override IEnumerator StartGameLevelContent()
    {
        while (true)
        {
            GameObject normalRock = Instantiate(ObjectPool.instance.normalRock);
            
            NetworkServer.Spawn(normalRock);
            yield return new WaitForSeconds(1f);
        }
    }
}