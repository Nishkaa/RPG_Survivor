using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Player player;
    private float moveSpeed;
    private Vector3 directionToPlayer;
    private Vector3 localScale;

    public GameObject Coin;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType(typeof(Player)) as Player;
        localScale = transform.localScale;
        moveSpeed = Random.Range(1.0f, 4f);
    }
    private void FixedUpdate()
    {
        MoveEnemy();
    }
    private void MoveEnemy()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;
    }
    private void LateUpdate()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            var deadEnemy = GetComponent<Rigidbody2D>().position;
            Destroy(collision.gameObject);
            Instantiate(Coin, deadEnemy, Quaternion.identity);
        }
    }
}
