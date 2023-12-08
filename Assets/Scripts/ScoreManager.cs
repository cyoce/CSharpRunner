using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    int score = 0;
    int highScore = 0;

    public void OnScoreIncrease(BunnyCounter bunnyCount)
    {
        score += 100;
        PlayerPrefs.SetInt("HighScore", score);
        highScore = PlayerPrefs.GetInt("HighScore");

        PrintScore();
        Debug.Log(score);
    }

    public void PrintScore()
    {
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    void Start()
    {
        PrintScore();
    }

    
    void Update()
    {
        
    }
}
