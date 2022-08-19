using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using System;
public class Weapons : MonoBehaviour
{
    public float Range;
    public Transform Target;

    bool Detected = false;
    Vector2 Direction;

    public GameObject Gun;
    public GameObject Bullet;
    public GameObject ShotgunBullet;

    public float FireRate;
    float nextTimeToFire;
    public Transform ShootPoint;
    public Transform shooting_position;
    public float force;

    public bool normalGun = true;
    public bool shotGun = false;
    public bool automatic = false;
    public bool laser = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }

    public void Look()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        Direction = Direction.normalized;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                }
            }
            if (Detected)
            {
                Gun.transform.up = Direction;
                if (Time.time > nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1 / FireRate;
                    Shoot();
                    ShootShotgun();
                    Automatic();
                    Laser();
                }
            }
        }
    }
    public void Shoot()
    {
        normalGun = true;
        if (normalGun)
        {
            FireRate = 1;
            GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, shooting_position.rotation);
            BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * force);
            StartCoroutine(CleanBulletWaste());
        }
        else
        {

        }
    }
    public void ShootShotgun()
    {
        if (shotGun == true)
        {
            FireRate = 1;
            GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, shooting_position.rotation);
            GameObject BulletIns1 = Instantiate(Bullet, ShootPoint.position, shooting_position.rotation);
            GameObject BulletIns2 = Instantiate(Bullet, ShootPoint.position, shooting_position.rotation);
            GameObject BulletIns3 = Instantiate(Bullet, ShootPoint.position, shooting_position.rotation);
            BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * force);
            BulletIns1.GetComponent<Rigidbody2D>().AddForce(Direction * 2 * force);
            BulletIns2.GetComponent<Rigidbody2D>().AddForce(Direction * 3 * force);
            BulletIns3.GetComponent<Rigidbody2D>().AddForce(Direction * 5 * force);
        }
        else
        {

        }
    }
    public void Automatic()
    {

        if (automatic == true)
        {
            FireRate = 3;
            GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, shooting_position.rotation);
            BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * force);

        }
        else
        {

        }
    }
    public void Laser()
    {

        if (laser == true)
        {
            FireRate = 10f;

            GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, shooting_position.rotation);
            BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * force);

        }
        else
        {

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WeaponOne")
        {
            shotGun = true;
            laser = false;
            normalGun = false;
            automatic = false;

            Destroy(collision.gameObject);
            Debug.Log(shotGun + " shotgun");
        }
        if (collision.gameObject.tag == "WeaponTwo")
        {
            automatic = true;
            laser = false;
            shotGun = false;
            normalGun = false;


            Destroy(collision.gameObject);
            Debug.Log(automatic + " automatic gun");
        }
        if (collision.gameObject.tag == "WeaponThree")
        {
            laser = true;
            shotGun = false;
            automatic = false;
            normalGun = false;
            Destroy(collision.gameObject);
            Debug.Log(laser + " laser");
        }
    }
    public IEnumerator CleanBulletWaste()
    {
        Debug.Log("Starting Coroutine");
        yield return new WaitForSeconds(1f);
        Debug.Log("Waiting Coroutine");
    }
}
