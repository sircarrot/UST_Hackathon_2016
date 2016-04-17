using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class HighScoreManager : MonoBehaviour {

    public Text singlePlayerScore1;
    public Text singlePlayerScore2;

    // Use this for initialization
    void Start () {
        float[] multiScores = BestScore.loadScore("multi");
        float[] singleScores = BestScore.loadScore("single");

        System.TimeSpan t = System.TimeSpan.FromSeconds(singleScores[0]);
        if (singleScores[0] > 3600)
        {
            singlePlayerScore1.text = string.Format("{0:D2}h:{1:D2}:{2:D2}:{3:D2}",
                        t.Hours,
                        t.Minutes,
                        t.Seconds,
                        t.Milliseconds);
        }
        else
        {
            singlePlayerScore1.text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                        t.Minutes,
                        t.Seconds,
                        t.Milliseconds);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
