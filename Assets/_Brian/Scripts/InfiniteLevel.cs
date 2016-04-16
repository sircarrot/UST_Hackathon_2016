using System;
using UnityEngine;
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
            Instantiate(ObjectPool.instance.normalRock);
            yield return new WaitForSeconds(1f);
        }
    }
}