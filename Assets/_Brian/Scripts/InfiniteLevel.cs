
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
            //Quaternion.Euler(0, 0, Random.Range(0f, 360f));
            float x = 0;
            float y = 0;
            int side = Random.Range(0,4);
            //Random for side of screen
            switch (side)
            {
                //Left
                case 0:
                    x = -10 + Random.Range(-10,10) / 10;
                    y = Random.Range(-60, 60) / 10;
                    break;
                //Up
                case 1:
                    x = Random.Range(-90, 90) / 10;
                    y = 7 + Random.Range(-10, 10) / 10;
                    break;
                //Right
                case 2:
                    x = 10 + Random.Range(-10, 10) / 10;
                    y = Random.Range(-60, 70) / 10;
                    break;
                //Down
                case 3:
                    x = Random.Range(-90, 90) / 10;
                    y = -7 + Random.Range(-10, 10) / 10;
                    break;
            }




                                                                                                //position
            GameObject normalRock = (GameObject) Instantiate(ObjectPool.instance.normalRock, new Vector3(x, y, 0), Quaternion.identity);
            
            NetworkServer.Spawn(normalRock);
            yield return new WaitForSeconds(1f);
        }
    }
}