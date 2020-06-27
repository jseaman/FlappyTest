using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour {
    public static GameManager gameManager;

    public Image gameOverImage;

	// Use this for initialization
	void Start () {
        gameManager = this;
	}
	
	public void GameOver()
    {
        ScoreManager.scoreManager.SaveHighestScore();
        gameOverImage.enabled = true;
        Invoke("RestartLevel", 2);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
