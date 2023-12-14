using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
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
        PrintScore();
    }

    public void PrintScore()
    {
        if(scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }

    void Start()
    {
        PrintScore();
        distanceManager = GetComponent<DistanceManager>();
    }
}
