using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;
public class LevelGenerator : MonoBehaviour
{
    public GameObject Mob1;
    public GameObject Mob2;
    public GameObject Mob3;
    public GameObject Mob4;
    public GameObject Mob5;
    public GameObject Mob6;
    public GameObject Mob7;
    public GameObject Mob8;
    public GameObject Mob9;
    public GameObject Mob10;

    public GameObject WeaponOne;
    public GameObject WeaponTwo;
    public GameObject WeaponThree;

    public GameObject BonusOneSpeed;

    public float distance;
    public float enemySpeed = 1;
    float SpawnTime;
    float WeaponSpawnTime = 30f;
    float BonusSpawnTime = 20f;
    public float health = 100f;

    public CountDownTimer TimerTEA;
    float mobOneSize = 1f;
    float mobTwoSize = 3f;
    float mobThreeSize = 0.1f;
    float mobFourSize = 0.3f;
    float mobFiveSize = 0.1f;
    float mobSixSize = 0.2f;
    float mobSevenSize = 1f;
    float mobEightSize = 0.3f;
    float mobNineSize = 0.1f;
    float mobTenSize = 7f;

    public void Start()
    {
        MobSpawn();
        StartCoroutine(WeaponSpawner());
        StartCoroutine(BonusSpawner());

    }
    public void Update()
    {
        if (TimerTEA.timeValue > 15)
        {
            SpawnTime = Random.Range(8f, 19f);
        }
        if (TimerTEA.timeValue > 30)
        {
            SpawnTime = Random.Range(7f, 18f);
        }
        if (TimerTEA.timeValue > 60)
        {
            SpawnTime = Random.Range(5f, 15f);
        }
        if (TimerTEA.timeValue > 120)
        {
            SpawnTime = Random.Range(3f, 10f);
        }
        if (TimerTEA.timeValue > 180)
        {
            SpawnTime = Random.Range(1f, 5f);
        }
        else
        {
            SpawnTime = Random.Range(1f, 20.0f);
        }
    }
    public void MobSpawn()
    {

        //LVL 1 Enemy
        //spawning Mob1
        var enemy = Instantiate(Mob1, new Vector2(Random.Range(-45, 45), Random.Range(25, 28)), Quaternion.identity);
        enemy.transform.localScale = new Vector3(mobOneSize, mobOneSize, 1);
        distance += 35;
        //LVL 2 Enemy
        //spawning Mob2
        var enemy2 = Instantiate(Mob2, new Vector2(Random.Range(-45, 45), Random.Range(25, 28)), Quaternion.identity);
        enemy2.transform.localScale = new Vector3(mobTwoSize, mobTwoSize, 1);
        distance += 35;
        //LVL 3 Enemy
        //spawning Mob3
        var enemy3 = Instantiate(Mob3, new Vector2(Random.Range(-45, 45), Random.Range(25, 28)), Quaternion.identity);
        enemy3.transform.localScale = new Vector3(mobThreeSize, mobThreeSize, 1);
        distance += 35;
        //LVL 4 Enemy
        //spawning Mob4
        var enemy4 = Instantiate(Mob4, new Vector2(Random.Range(-45, 45), Random.Range(25, 28)), Quaternion.identity);
        enemy4.transform.localScale = new Vector3(mobFourSize, mobFourSize, 1);
        distance += 35;
        //LVL 5 Enemy
        //spawning Mob5
        var enemy5 = Instantiate(Mob5, new Vector2(Random.Range(-45, 45), Random.Range(25, 28)), Quaternion.identity);
        enemy5.transform.localScale = new Vector3(mobFiveSize, mobFiveSize, 1);
        distance += 35;
        //LVL 6 Enemy
        //spawning Mob6
        var enemy6 = Instantiate(Mob6, new Vector2(Random.Range(-45, 45), Random.Range(-26, -24)), Quaternion.identity);
        enemy6.transform.localScale = new Vector3(mobSixSize, mobSixSize, 1);
        distance += 35;
        //LVL 7 Enemy
        //spawning Mob7
        var enemy7 = Instantiate(Mob7, new Vector2(Random.Range(-45, 45), Random.Range(-26, -24)), Quaternion.identity);
        enemy7.transform.localScale = new Vector3(mobSevenSize, mobSevenSize, 1);
        distance += 35;
        //LVL 8 Enemy
        //spawning Mob8
        var enemy8 = Instantiate(Mob8, new Vector2(Random.Range(-45, 45), Random.Range(-26, -24)), Quaternion.identity);
        enemy8.transform.localScale = new Vector3(mobEightSize, mobEightSize, 1);
        distance += 35;
        //LVL 9 Enemy
        //spawning Mob9
        var enemy9 = Instantiate(Mob9, new Vector2(Random.Range(-45, 45), Random.Range(-26, -24)), Quaternion.identity);
        enemy9.transform.localScale = new Vector3(mobNineSize, mobNineSize, 1);
        distance += 35;
        //LVL 10 Enemy
        //spawning Mob10
        var enemy10 = Instantiate(Mob10, new Vector2(Random.Range(-45, 45), Random.Range(-26, -24)), Quaternion.identity);
        enemy10.transform.localScale = new Vector3(mobTenSize, mobTenSize, 1);
        distance += 35;
        //spawn cooldown
        StartCoroutine(Spawner());

    }
    public void WeaponSpawn()
    {
        //LVL First Weapon
        //spawning Weapon

        var Weapon2 = Instantiate(WeaponTwo, new Vector2(Random.Range(-30, 30), Random.Range(-10, 18)), Quaternion.identity);
        Weapon2.transform.localScale = new Vector3(2f, 2f, 2f);
        distance += 20;
        Destroy(Weapon2, 20f);

        var Weapon3 = Instantiate(WeaponThree, new Vector2(Random.Range(-30, 30), Random.Range(-10, 18)), Quaternion.identity);
        Weapon3.transform.localScale = new Vector3(2f, 2f, 2f);
        distance += 20;
        Destroy(Weapon3, 20f);
        StartCoroutine(WeaponSpawner());

    }
    public void BonusesSpawn()
    {
        var BonusSpeed = Instantiate(BonusOneSpeed, new Vector2(Random.Range(-30, 30), Random.Range(-16, 18)), Quaternion.identity);
        BonusSpeed.transform.localScale = new Vector3(1f, 1f, 1f);
        distance += 30;
        Destroy(BonusSpeed, 10f);
        StartCoroutine(BonusSpawner());
    }
    public IEnumerator Spawner()
    {
        //Assuming the enemy is always moving
        yield return new WaitForSeconds(SpawnTime);
        MobSpawn();
    }
    public IEnumerator WeaponSpawner()
    {
        //Assuming the enemy is always moving
        yield return new WaitForSeconds(WeaponSpawnTime);
        WeaponSpawn();
    }
    public IEnumerator BonusSpawner()
    {
        //Assuming the enemy is always moving
        yield return new WaitForSeconds(BonusSpawnTime);

    }
}
