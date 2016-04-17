using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HighScoreManager : MonoBehaviour {

    public Text[] singlePlayerScore;
    public Text[] multiPlayerScore;

    public void backtoMain()
    {
        SceneManager.LoadScene(MenuNavigation.MENU);
    }

    // Use this for initialization
    void Start () {
        float[] multiScores = BestScore.loadScore("multi");
        float[] singleScores = BestScore.loadScore("single");
        System.TimeSpan t;
        
        for(int i = 0;i < 5; i++)
        {
            t = System.TimeSpan.FromSeconds(singleScores[i]);
            if (singleScores[i] > 3600)
            {
                singlePlayerScore[i].text = string.Format("{0:D2}h:{1:D2}:{2:D2}:{3:D2}",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
            }
            else
            {
                singlePlayerScore[i].text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
            }

            t = System.TimeSpan.FromSeconds(multiScores[i]);
            if (multiScores[i] > 3600)
            {
                multiPlayerScore[i].text = string.Format("{0:D2}h:{1:D2}:{2:D2}:{3:D2}",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
            }
            else
            {
                multiPlayerScore[i].text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
            }
        }

        

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
