using System.Collections;
using UnityEngine;

public abstract class GameLevel : MonoBehaviour
{
    public GameManager holder;
    public abstract IEnumerator StartGameLevelContent();
    public abstract void clearAllObjects();

    private Coroutine routine;

    public void StartGameLevel()
    {
        routine = StartCoroutine(StartGameLevelContent());
    }

    public void StopGameLevel()
    {
        StopCoroutine(routine);
        clearAllObjects();
    }
}
