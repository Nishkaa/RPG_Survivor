using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;
public class LevelTwiGenerator : MonoBehaviour
{
    public GameObject LaserWall;
    public float LaserSpawnTime = 1f;
    public float distance;
    public float lowest = 0.2f;
    public float highest = 0.8f;
    public float speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        LaserGen();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FixedUpdate()
    {

    }
    public void LaserGen()
    {
        var LaserW = Instantiate(LaserWall, new Vector2(Random.Range(-45, 45), Random.Range(-26, 28)), Quaternion.identity);
        LaserW.transform.localScale = new Vector3(Random.Range(lowest, highest), 1, 1);
        distance += 30;
        StartCoroutine(SpawnCooldown());
    }
    public IEnumerator SpawnCooldown()
    {
        //Assuming the enemy is always moving
        yield return new WaitForSeconds(LaserSpawnTime);
        LaserGen();
    }
}
