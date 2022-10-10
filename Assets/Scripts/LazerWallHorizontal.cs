using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using System;
public class LazerWallHorizontal : MonoBehaviour
{
    private Rigidbody2D rb;
    float speed = -2f;
    private float directionFloat = 3f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        // rb.velocity = new Vector2(speed, 0f);
        //moveLaser();
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
