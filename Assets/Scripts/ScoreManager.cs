using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    DistanceManager distanceManager;

    int score = 0;
    int highScore = 0;

    public void OnScoreIncrease(BunnyCounter bunnyCount)
    {
        Debug.Log("score increase: " + score);
        score += 100;
        PlayerPrefs.SetInt("HighScore", score);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScore += distanceManager.distanceRan;

        CheckHighScore();
        PrintScore();
    }

    public void PrintScore()
    {
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    void CheckHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0)) 
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    void Start()
    {
        PrintScore();
        distanceManager = GetComponent<DistanceManager>();
    }

    
    void Update()
    {
        
    }
}
