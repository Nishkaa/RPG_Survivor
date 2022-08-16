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
        Debug.Log("quit");
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Replay()
    {
        SceneManager.LoadScene("SceneOne");
    }
}
