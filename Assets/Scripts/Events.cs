using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<BackgroundMusic>().PlaySound("MainTheme");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        FindObjectOfType<BackgroundMusic>().PlaySound("MainTheme");
    }
}
