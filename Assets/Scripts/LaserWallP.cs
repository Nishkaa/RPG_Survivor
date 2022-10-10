using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using System;

public class LaserWallP : MonoBehaviour
{
    private Rigidbody2D rb;
    float speed = -2f;
    private float directionFloat = 3f;
    private void Awake()
    {

    }
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //  rb.velocity = new Vector2(0f, speed);
        // moveLaser();
    }
    public void moveLaser()
    {
        StartCoroutine(Direction());
    }
    private IEnumerator Direction()
    {
        //Assuming the enemy is always moving
        yield return new WaitForSeconds(directionFloat);
        speed = 2;
        yield return new WaitForSeconds(directionFloat);
        speed = -2;
        moveLaser();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
