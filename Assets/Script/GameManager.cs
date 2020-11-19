using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("ScoreElements")]
    public int score = 0;
    public int highscore = 0;
    public int highscoreSV = 0;
    public Text TimeText;
    public Text ScoreText;
    public Text HighScore;
    public Text HighScoreSV;
    private float timeleft = 60;
    [Header("GameOver")]
    public GameObject GameOverPanel;
    public Text GameOverScore;
    int LossPoints = 0;
    public GameObject[] XImages;
    [Header("Audio")]
    public AudioClip SliceSound;
    private AudioSource audioSource;

    public string GetCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string SceneName = currentScene.name;
        return SceneName;
    }

    private void Awake()
    {
        string SceneName = GetCurrentScene();
        highscore = PlayerPrefs.GetInt("HighScore");
        highscoreSV = PlayerPrefs.GetInt("HighScoreSurvival");
        if (SceneName == "TimeMode")
        {
            HighScore.text = "Best: " + highscore;
        }
        else if (SceneName == "SurvivalMode")
        {
            HighScoreSV.text = "Best: " + highscoreSV;
        }
     
        audioSource = GetComponent<AudioSource>();
        LossPoints = 0;
    }

    public void IncreaseScore(int points)
    {
        string SceneName = GetCurrentScene();
        score += points;
        ScoreText.text = score.ToString();
        if (SceneName == "TimeMode")
        {
            if (score > highscore)
            {
                PlayerPrefs.SetInt("HighScore", score);
                HighScore.text = "Best: " + score;
            }
        }
        else if (SceneName == "SurvivalMode")
        {
            if (score > highscoreSV)
            {
                PlayerPrefs.SetInt("HighScoreSurvival", score);
                HighScoreSV.text = "Best: " + score;
            }
        }
    }
  
    private void Update()
    {
        string SceneName = GetCurrentScene();       
        if (SceneName == "TimeMode")
        {
            timeleft -= Time.deltaTime;
            TimeText.text = timeleft.ToString("00");
            if (timeleft <= 0 )
            {
                timeleft = 0;
                Time.timeScale = 0;
                GameOverPanel.SetActive(true);
                GameOverScore.text = "Score: " + score.ToString();
            }
        }
        else if(SceneName == "SurvivalMode")
        {
            if(LossPoints == 3)
            {
                Time.timeScale = 0;
                GameOverPanel.SetActive(true);
                GameOverScore.text = "Score: " + score.ToString();
            }
        }
    }

    public void OnBombHitTimeMode()
    {             
        timeleft -= 10;      
    }
   
    public void OnBombHitSurvival()
    {
        GameObject LossImages = XImages[LossPoints];
        LossPoints++;   
        LossImages.SetActive(true);
    }
   
    public void Restart()
    {   
        timeleft = 60;
        score = 0;
        ScoreText.text = 0.ToString();
        LossPoints = 0;
        Time.timeScale = 1;
        GameOverPanel.SetActive(false);
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Cutable"))
        {
            Destroy(g);
        }  
        foreach(GameObject IKS in XImages)
        {
            IKS.SetActive(false);
        }
    }
}


