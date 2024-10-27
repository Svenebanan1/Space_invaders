using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbeam : Projectile
{
    float Speed = 12f;


    int animationFrame;
    private void Awake()
    {
        direction = Vector3.down;

    }


    void Update()
    {

        transform.position += Speed * Time.deltaTime * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject);

        //s� fort den krockar med n�got s� ska den f�rsvinna.

    }
}
