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

    public GameObject LaserWallVertical;
    public GameObject LaserWallHorizontal;
    public GameObject DiamondBonus;
    private float LaserSpawnTime = 0.5f;
    private float DiamondSpawnTime = 0.3f;
    private float distance = 1f;
    private float lowest = 3f;
    private float highest = 3f;
    private float speed = 1;
    public float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 150; i++)
        {
            LaserGen();
        }

        DiamondGen();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LaserGen()
    {
        var LaserWV = Instantiate(LaserWallVertical, new Vector2(Random.Range(-43, 43), Random.Range(-24, 24)), Quaternion.identity);
        LaserWV.transform.localScale = new Vector3(Random.Range(lowest, highest), Random.Range(lowest, highest), 1);

        distance += 15f;

        var LaserWH = Instantiate(LaserWallHorizontal, new Vector2(Random.Range(-43, 43), Random.Range(-24, 24)), Quaternion.identity);
        LaserWH.transform.localScale = new Vector3(Random.Range(lowest, highest), Random.Range(lowest, highest), 1);
        distance += 15f;
        //StartCoroutine(SpawnCooldown());
    }
    public void DiamondGen()
    {
        var Diamond = Instantiate(DiamondBonus, new Vector2(Random.Range(-43, 43), Random.Range(-24, 24)), Quaternion.identity);
        Diamond.transform.localScale = new Vector3(1, 1, 1);
        distance += 2f;
        Destroy(Diamond, 20);
        StartCoroutine(DiamonSpawn());
    }
    public IEnumerator SpawnCooldown()
    {
        //Assuming the enemy is always moving
        yield return new WaitForSeconds(LaserSpawnTime);
        LaserGen();
    }
    public IEnumerator DiamonSpawn()
    {
        //Assuming the enemy is always moving
        yield return new WaitForSeconds(DiamondSpawnTime);
        DiamondGen();
    }
}
