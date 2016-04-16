using System;
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
        print("it works");


        yield return null;
    }
}