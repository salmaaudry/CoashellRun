using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Text highscoreText;
    // Start is called before the first frame update
    
    private void Update()
    {
        highscoreText.text = "" + PlayerPrefs.GetInt("HighScore", 0);
    }
    public void Play(string sceneName){
        SceneManager.LoadScene("Game");
        FindObjectOfType<BackgroundMusic>().PlaySound("MainTheme");
    }

    public void Exit(){
        Application.Quit();
    }
}