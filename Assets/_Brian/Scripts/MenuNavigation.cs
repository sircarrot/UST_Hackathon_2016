using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuNavigation : MonoBehaviour {

    public static string MENU = "MainMenu";
    public static string GAME_SCENE = "GameScene";

    public GameObject singleplayer;
    public GameObject multiplayer;

    public void GotoGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    public void OnClickPlay()
    {
        //do something
    }

    public void GotoSinglePlayer()
    {
        Pass.isMultiplayer = false;
        SceneManager.LoadScene(GAME_SCENE);
    }

    public void GotoMultiplayer()
    {
        Pass.isMultiplayer = true;
        SceneManager.LoadScene(GAME_SCENE);
    }
}
