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
        SceneManager.LoadScene("BonusWinScene");
    }

    public void WinGameNoBonus()
    {
        SceneManager.LoadScene("NormalWinScene");
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
