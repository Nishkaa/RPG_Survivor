using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using System;

public class SystemCon : MonoBehaviour
{
    public GameObject BackToMenu;
    public GameObject Replay;
    public bool Esc = false;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SceneOne");
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Esc == false)
        {
            Esc = true;
            Time.timeScale = 0;

            BackToMenu.gameObject.SetActive(true);
            Replay.gameObject.SetActive(true);

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Esc == true)
        {
            Esc = false;
            Time.timeScale = 1;
            BackToMenu.gameObject.SetActive(false);
            Replay.gameObject.SetActive(false);
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
