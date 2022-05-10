using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{


    public GameObject Weapon_One;
    public GameObject SpawnPoint;
    public float distance;
    public float SpawnTime = 0.1f;

    public Transform ShootPoint;
    public Transform shooting_position;

    public Vector2 vertical;
    public Vector2 horizontal;
    public float force;
    public void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        //spawning Mob1
        var position = new Vector2(SpawnPoint, 0);
        Instantiate(Weapon_One, position, Quaternion.identity);




        //spawn cooldown
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(SpawnTime);
        Spawn();
    }
}
