using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject Mob1;
    public float distance;
    public float SpawnTime = 1f;
    public void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        //spawning Mob1
        var enemy = Instantiate(Mob1, new Vector2(Random.Range(1, 10), Random.Range(1, 10)), Quaternion.identity);
        enemy.transform.localScale = new Vector3(1, 1, 1);
        distance += 1;

        //Destroy after 60 seconds
        Destroy(enemy, 60);

        //spawn cooldown
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(SpawnTime);
        Spawn();
    }
}
