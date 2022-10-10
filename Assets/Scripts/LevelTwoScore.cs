using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using System;

public class LevelTwoScore : MonoBehaviour
{
    public Text scoreText;
    public Text PlusOne;
    public Text highscoreText;
    public Text highscoreTextThumbnail;
    public static LevelTwoScore instance;
    public float scoreWait = 0.5f;
    int wallScore = 0;
    int highscoreWall = 0;
    // Start is called before the first frame update
    void Start()
    {
        highscoreWall = PlayerPrefs.GetInt("Wallhighscore", 0);
        highscoreText.text = highscoreWall.ToString();

        highscoreTextThumbnail.text = highscoreWall.ToString();
    }

    public void Awake()
    {
        instance = this;
    }
    public void AddPoint()
    {
        PlusOne.gameObject.SetActive(true);
        StartCoroutine(AddOneScore());
        wallScore += 1;
        scoreText.text = wallScore.ToString();
        if (highscoreWall < wallScore)
        {
            PlayerPrefs.SetInt("Wallhighscore", wallScore);

        }
    }
    public IEnumerator AddOneScore()
    {
        Debug.Log("Starting Coroutine");
        yield return new WaitForSeconds(scoreWait);
        PlusOne.gameObject.SetActive(false);

    }
}
