using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int visibleScore;
    public int highScore; 
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        visibleScore = 0;
        highScore = PlayerPrefs.GetInt("score");
        highScoreText.text = highScore.ToString();
    }

    public void IncreaseScore(int value)
    {
        visibleScore += value;
        textScore.text = visibleScore.ToString();
        if (visibleScore > highScore) highScore = visibleScore;
    }

    public void EndGame()
    {
        if(PlayerPrefs.GetInt("score")<=highScore) PlayerPrefs.SetInt("score", highScore);
        highScoreText.text = PlayerPrefs.GetInt("score").ToString();
    }
}
