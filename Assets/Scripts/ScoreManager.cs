using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager scoreManager;

    public Text scoreText;
    public Text highestScoreText;

    int score = 0;

    // Use this for initialization
    void Start() {
        scoreManager = this;
        highestScoreText.text = "Highest : " + GetHighestScore().ToString();
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void SaveHighestScore()
    {
        if (score > GetHighestScore())
            PlayerPrefs.SetInt("HighestScore", score);
    }

    private int GetHighestScore()
    {
        if (PlayerPrefs.HasKey("HighestScore"))
            return PlayerPrefs.GetInt("HighestScore");
        else
            return 0;
    }

}
