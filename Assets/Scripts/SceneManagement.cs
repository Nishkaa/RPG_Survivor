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
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        Cursor.visible = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void Replay()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("SceneOne");
    }
    public void GoToOptions()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Options");
    }

    public void GoToCredits()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Credits");
    }
}
