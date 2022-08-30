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
    private float LaserSpawnTime = 1f;
    private float DiamondSpawnTime = 1f;
    private float distance = 1f;
    private float lowest = 1f;
    private float highest = 1f;
    private float speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        LaserGen();
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
        Destroy(LaserWV, 10);
        distance += 1f;

        var LaserWH = Instantiate(LaserWallHorizontal, new Vector2(Random.Range(-43, 43), Random.Range(-24, 24)), Quaternion.identity);
        LaserWH.transform.localScale = new Vector3(Random.Range(lowest, highest), Random.Range(lowest, highest), 1);
        Destroy(LaserWV, 10);
        distance += 1f;

        StartCoroutine(SpawnCooldown());
    }
    public void DiamondGen()
    {
        var Diamond = Instantiate(DiamondBonus, new Vector2(Random.Range(-43, 43), Random.Range(-24, 24)), Quaternion.identity);
        Diamond.transform.localScale = new Vector3(1, 1, 1);
        distance += 10f;
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
