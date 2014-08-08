using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour 
{
    public static ScoreManager _instance;
    public dfLabel currentScore;
    public dfLabel highScore;

    public int score = 0;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        currentScore.Text = score + "";
        highScore.Text = PlayerPrefs.GetInt("highScore", 0) + "";
    }

    public void AddScore(int score)
    {
        this.score += score;
        UpdateHighScore();
        UpdateScore();
    }

    public void UpdateHighScore()
    {
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }


}
