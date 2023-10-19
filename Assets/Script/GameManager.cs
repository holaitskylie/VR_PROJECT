using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;

    public Text scoreText;
    public Text timeText;
    private int score = 0;
    private float timer = 60f;

    public GameObject gameoverUI;
    public GameObject textUI;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timeText.text = "Time : " + (int)timer;

        if(timer <= 0)
        {
            EndGame();
        
        }
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }

    }

    void EndGame()
    {
        isGameover = true;
        textUI.SetActive(false);
        gameoverUI.SetActive(true);
    }
}
