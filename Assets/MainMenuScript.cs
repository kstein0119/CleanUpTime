using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void FailGame()
    {
        SceneManager.LoadScene("FailScene");
    }

    public void WinGameTimeBonus()
    {
        // load "yay you win and you're fast as hell" and show like a cookie or something 
    }

    public void WinGameNoBonus()
    {
        // load "yay you win but not fast"
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
