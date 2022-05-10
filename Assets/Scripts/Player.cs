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
    public float jumpVelocity = 3f;
    //public AudioSource Jump;

    // Start is called before the first frame update
    void Start()
    {

        speed = 10f;


        Player2D = gameObject.GetComponent<Rigidbody2D>();
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


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }
}
