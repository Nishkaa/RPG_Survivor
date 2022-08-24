using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using System;
public class SceneManagement : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SceneOne");
    }
    public void GoToOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
