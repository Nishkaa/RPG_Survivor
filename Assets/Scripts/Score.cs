using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text PlusOne;
    public Text highscoreText;
    public static Score instance;
    public float scoreWait = 0.5f;
    int score = 0;
    int highscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();
    }

    public void Awake()
    {
        instance = this;
    }
    public void AddPoint()
    {
        PlusOne.gameObject.SetActive(true);
        StartCoroutine(AddOneScore());
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
    public IEnumerator AddOneScore()
    {
        Debug.Log("Starting Coroutine");
        yield return new WaitForSeconds(scoreWait);
        PlusOne.gameObject.SetActive(false);

    }
}
