using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int visibleScore;
    public int highScore;
    public List<int> highScores;
    public int[] rankedScores;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI leaderBoard;

    int highest;

    private void Start()
    {
        visibleScore = 0;
        highScore = PlayerPrefs.GetInt("score");
        highScoreText.text = highScore.ToString();
        //StartCoroutine(WaitandDebug());
    }

    public void IncreaseScore(int value)
    {
        visibleScore += value;
        if(textScore != null) textScore.text = visibleScore.ToString();
        if (visibleScore > highScore) highScore = visibleScore;
    }

    public void EndGame()
    {
        highScores.Add(visibleScore);
        visibleScore = 0;
        foreach (int oldScore in rankedScores)
        {
            highScores.Add(oldScore);
        }
        if(PlayerPrefs.GetInt("score")<=highScore) PlayerPrefs.SetInt("score", highScore);
        highScoreText.text = PlayerPrefs.GetInt("score").ToString();
        leaderBoard.text = "";
        for (int i = 0; i < 5; i++)
        {
            rankedScores[i] = highScores.Max();
            highScores.Remove(highScores.Max());
            leaderBoard.text += i+1 + " : " + rankedScores[i] + "\n";
        }

        highScore = rankedScores[0];

        highScores.Clear();
        
        Debug.Log(leaderBoard.text);
        //StartCoroutine(WaitandDebug());
    }

    IEnumerator WaitandDebug()
    {
        yield return new WaitForSeconds(3f);
        EndGame();
    }
}
