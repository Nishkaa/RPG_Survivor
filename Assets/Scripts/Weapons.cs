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
    public GameObject LaserBullet;
    public GameObject ShotgunBullet;

    public float FireRate;
    float nextTimeToFire;
    public Transform ShootPoint;
    public Transform shooting_position;
    public float force;
    public float LaserForce;

    public bool normalGun = true;
    public bool shotGun = false;
    public bool automatic = false;
    public bool laser = false;

    // Start is called before the first frame update
    void Start()
    {
        normalGun = true;
        automatic = false;
        laser = false;
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

                    Automatic();
                    Laser();

                }
            }
        }
    }
    public void Shoot()
    {
        Debug.Log("Normalgun " + normalGun);
        if (normalGun == true)
        {

            FireRate = 1;
            GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, shooting_position.rotation);
            BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * force);

        }
        else
        {

        }
    }
    public void Automatic()
    {

        if (automatic == true)
        {
            FireRate = 4;
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
            normalGun = false;
            Debug.Log("laser " + laser);
            Debug.Log("Normalgun " + normalGun);

            FireRate = 0.7f;
            GameObject LaserIns = Instantiate(LaserBullet, ShootPoint.position, shooting_position.rotation);
            LaserIns.GetComponent<Rigidbody2D>().AddForce(Direction * LaserForce);

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

            laser = false;
            normalGun = false;
            automatic = false;

            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "WeaponTwo")
        {
            automatic = true;
            laser = false;
            normalGun = false;

            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "WeaponThree")
        {
            laser = true;

            automatic = false;
            normalGun = false;
            Destroy(collision.gameObject);
        }
    }
}
