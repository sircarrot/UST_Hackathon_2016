
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

    int count = 0;

    public override IEnumerator StartGameLevelContent()
    {
        while (true)
        {
            float x = 0;
            float y = 0;
            float r1 = 0;
            float r2 = 0;
            Quaternion rot = Quaternion.identity;
            int side = Random.Range(0,4);
            //Random for side of screen
            switch (side)
            {
                //Left
                case 0:
                    x = -10 + Random.Range(-10,10) / 10;
                    y = Random.Range(-60, 60) / 10;

                    if (y > 0) { r1 = 225f; r2 = 315f - (y/6*45); }
                    else { r1 = 225f - (y / 6 * 45); r2 = 315f ; }

                    rot = Quaternion.Euler(0, 0, Random.Range(r1, r2));
                    break;
                //Up
                case 1:
                    x = Random.Range(-90, 90) / 10;
                    y = 7 + Random.Range(-10, 10) / 10;

                    if (x > 0) { r1 = 135f; r2 = 225f - (x / 9 * 45); }
                    else { r1 = 135f - (x / 9 * 45); r2 = 225f; }

                    rot = Quaternion.Euler(0, 0, Random.Range(r1, r2)); break;
                //Right
                case 2:
                    x = 10 + Random.Range(-10, 10) / 10;
                    y = Random.Range(-60, 60) / 10;

                    if (y > 0) { r1 = 45f; r2 = 135f - (y / 6 * 45); }
                    else { r1 = 45f - (y / 6 * 45); r2 = 135f; }

                    rot = Quaternion.Euler(0, 0, Random.Range(r1, r2));
                    break;
                //Down
                case 3:
                    x = Random.Range(-90, 90) / 10;
                    y = -7 + Random.Range(-10, 10) / 10;

                    if (x > 0) { r1 = -45f; r2 = 45f - (x / 9 * 45); }
                    else { r1 = -45f - (x / 9 * 45); r2 = 45f; }

                    rot = Quaternion.Euler(0, 0, Random.Range(r1, r2));
                    break;
            }



            //20% chance of bouncing rock
            int rockspawn = Random.Range(0, 3);
            GameObject normalRock;
            switch (rockspawn)
            {
                case 0:
                    normalRock = (GameObject)Instantiate(ObjectPool.instance.bouncingRock, new Vector3(x, y, 0), rot);
                    NetworkServer.Spawn(normalRock);
                    break;
                default:
                    normalRock = (GameObject)Instantiate(ObjectPool.instance.normalRock, new Vector3(x, y, 0), rot);
                    NetworkServer.Spawn(normalRock);
                    break;
            }

            //RandomItem
            if (count % 3 == 0)
            {
                x = Random.Range(-8, 8);
                y = Random.Range(-4, 4);
                GameObject rnditem;
                rnditem = (GameObject)Instantiate(ObjectPool.instance.RandomItem, new Vector3(x, y, 0), Quaternion.identity);
                NetworkServer.Spawn(normalRock);
            }
            count++;

            yield return new WaitForSeconds(1f);
        }
    }
}