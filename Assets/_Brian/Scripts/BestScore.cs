using UnityEngine;

public class BestScore
{
    public static void saveScore(string playerMode,float highest)
    {
        float[] allScore = loadScore(playerMode);
        for(int i = 0;i < 5; i++)
        {
            if(highest > allScore[i])
            {
                for(int j = 4;j > i + 1; j--)
                {
                    allScore[j] = allScore[j-1];
                }
                allScore[i] = highest;
                break;
            }
        }

        //save
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat(playerMode + "Record" + i, allScore[i]);
        }
    }

    public static float[] loadScore(string playerMode)
    {
        float[] scores = new float[5];
        for (int i = 0; i < 5; i++)
        {
            scores[i] = PlayerPrefs.GetFloat(playerMode + "Record" + i,0f);
        }
        return scores;
    }
}