using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
public class CountDownTimer : MonoBehaviour
{
    public float timeValue = 0;
    public Text timerText;
    float minutes;
    float seconds;
    public Text Survived;
    public GameObject BackToMenu;
    public GameObject Replay;
    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (timeValue > 1200)
        {
            Time.timeScale = 0;
            Survived.gameObject.SetActive(true);
            BackToMenu.gameObject.SetActive(true);
            Replay.gameObject.SetActive(true);

        }
        if (timeValue > 0)
        {
            timeValue += Time.deltaTime;
        }

        else
        {
            timeValue = 0;
        }
        DisplayTime(timeValue);
    }
    public void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay == 0)
        {
            timeToDisplay = 0;
        }
        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
