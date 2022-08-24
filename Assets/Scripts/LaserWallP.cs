using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWallP : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2f;
    public float directionFloat = 2f;
    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        moveLaser();

    }
    public void moveLaser()
    {
        rb.velocity = new Vector2(0f, speed);
        speed = 2f;
        StartCoroutine(Direction());
    }
    public IEnumerator Direction()
    {
        //Assuming the enemy is always moving
        speed = -2f;
        yield return new WaitForSeconds(directionFloat);
        moveLaser();
    }

}
