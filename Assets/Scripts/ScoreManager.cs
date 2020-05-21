using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager scoreManager;

    public Text scoreText;

    int score = 0;

	// Use this for initialization
	void Start () {
        scoreManager = this;
	}

    public void UpdateScore (int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

}
