using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    void Start()
    {
        int score = 0;
        int highScore = 0;

        scoreText.text = "Bunnies Collected: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    
    void Update()
    {
        
    }
}
