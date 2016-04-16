using UnityEngine;
using System.Collections;

public class UFOBoss : MonoBehaviour {

    Coroutine routine;
    public float speed = 5f;
    bool goingUp = true;

    // Use this for initialization
    void Start () {
        routine = StartCoroutine(movement());
	}

    float verticalMovement()
    {
        if (goingUp && transform.position.y > 1.5f)
        {
            goingUp = false;
        }
        else if (!goingUp && transform.position.y < -0.5f)
        {
            goingUp = true;
        }
        return (goingUp ? 1f : -1f) * speed;
    }

    IEnumerator movement()
    {
        Vector3 targetRight = new Vector3(8, 1);
        Vector3 targetLeft = new Vector3(-8, 1);
        
        while (true)
        {
            //move to right
            while (targetRight.x - transform.position.x > 0.5)
            {
                transform.position = Vector3.Lerp(transform.position, targetRight, GameManager.enemySpeedScale * Time.deltaTime * speed / 10);
                Debug.Log(goingUp);
                transform.position += new Vector3(speed, verticalMovement()) * GameManager.enemySpeedScale * Time.deltaTime / 3;
                yield return new WaitForFixedUpdate();
            }
            //move to left
            while(transform.position.x - targetLeft.x  > 0.5)
            {
                transform.position = Vector3.Lerp(transform.position, targetLeft, GameManager.enemySpeedScale * Time.deltaTime * speed / 10);
                transform.position -= new Vector3(speed, verticalMovement()) * GameManager.enemySpeedScale  * Time.deltaTime / 3;
                yield return new WaitForFixedUpdate();
            }
        }

        yield return null;
    }

    void OnDestroy()
    {
        StopCoroutine(routine);
    }

    public void getHit()
    {
        StopCoroutine(routine);
    }
}
