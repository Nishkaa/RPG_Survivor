using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using System;
public class Bullet : MonoBehaviour
{

    public float deathTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(collision.gameObject, 0.4f);
            //Enemy Death Particle System Animation

        }

    }
    public IEnumerator WaitOneSecond()
    {

        //Assuming the enemy is always moving
        yield return new WaitForSeconds(deathTime);
        //pause game

    }
}