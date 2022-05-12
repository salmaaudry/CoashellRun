﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    // public GameObject gameOverPanel;
    public static int numberOfCoins;
    public Text coinsText;
    public GameOverScreen gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        numberOfCoins = 0;
        FindObjectOfType<BackgroundMusic>().PlaySound("MainTheme");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0;
            // gameOverPanel.SetActive(true);
            if(numberOfCoins > PlayerPrefs.GetInt("HighScore", 0))
            {
                // newRecordPanel.SetActive(true);
                // newRecordText.text = "New Record" + numberOfCoins;
                PlayerPrefs.SetInt("HighScore", numberOfCoins);
            }
            
            gameOverScreen.Setup(numberOfCoins);
        }

        coinsText.text = "Score " + numberOfCoins;
    }
}
