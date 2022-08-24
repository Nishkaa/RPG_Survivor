using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using System;
public class Player : MonoBehaviour
{
    public float vertical;
    public float horizontal;
    private Rigidbody2D Player2D;
    public float speed;
    public SystemCon syscon;

    public Text DeadTxt;
    public GameObject BackToMenu;
    public GameObject Replay;

    public GameObject ScoreThumbnail;
    public GameObject ScoreText;
    public GameObject HighScoreThumbnail;
    public GameObject HighScoreText;

    public GameObject PlayerObj;
    public GameObject SpawnParticleSystem;
    public ParticleSystem Death;
    public ParticleSystem DashPS;
    public AudioSource TakeCoin;
    public AudioSource PlayerDeath;

    float fontSizeTime = 0.3f;
    public Text changingText;
    public Text changingTextName;

    public float DashSpeed = 5f;
    public float DashTime = 0.7f;
    // Start is called before the first frame update
    void Start()
    {

        SpawnParticleSystem.SetActive(true);
        Player2D = gameObject.GetComponent<Rigidbody2D>();
        Cursor.visible = true;
    }
    public void FixedUpdate()
    {
        //left and right Pressing A or D
        horizontal = Input.GetAxisRaw("Horizontal");
        //up and down Pressing W or S
        vertical = Input.GetAxisRaw("Vertical");

        //Move left or right
        if (horizontal > 0.5f || horizontal < -0.5f)
        {

            transform.Translate(new Vector3(horizontal * speed * Time.deltaTime, 0f, 0f));
        }
        if (vertical > 0.5f || vertical < -0.5f)
        {

            transform.Translate(new Vector3(0f, vertical * speed * Time.deltaTime, 0f));
        }
    }
    public void Update()
    {
        speed = 4;
        Dashing();
    }
    public void Dashing()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());

        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            changingText.fontSize = 90;
            changingTextName.fontSize = 90;
            StartCoroutine(FontSizeCD());
            //Plays coin sound
            TakeCoin.Play();

            //Player Takes Coin
            Destroy(collision.gameObject);

            //Adds 1 point to Score
            Score.instance.AddPoint();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(WaitOneSecond());

            //Destroy Enemy Object
            Destroy(collision.gameObject);
            //Disable PlayerObj

            PlayerObj.SetActive(false);
            //Display Death text
            DeadTxt.gameObject.SetActive(true);

            //Display Menu options
            ScoreThumbnail.gameObject.SetActive(true);
            ScoreText.gameObject.SetActive(true);
            HighScoreThumbnail.gameObject.SetActive(true);
            HighScoreText.gameObject.SetActive(true);
            BackToMenu.gameObject.SetActive(true);
            Replay.gameObject.SetActive(true);

            //Disable player collider
            GetComponent<Collider2D>().enabled = false;

            //Play Player Death SFX
            PlayerDeath.Play();

            //Player death Particle System Animation
            Death.Play();
        }
    }

    public IEnumerator WaitOneSecond()
    {
        //Assuming the enemy is always moving
        yield return new WaitForSeconds(1f);
        //pause game
        Time.timeScale = 0;
    }
    public IEnumerator FontSizeCD()
    {
        //Assuming the enemy is always moving
        yield return new WaitForSeconds(fontSizeTime);
        changingText.fontSize = 56;
        changingTextName.fontSize = 56;

    }
    public IEnumerator Dash()
    {
        DashPS.Play();
        speed = 50;
        Debug.Log("Start " + speed);
        yield return new WaitForSeconds(DashTime);
        Debug.Log("Finish " + speed);

    }
}
