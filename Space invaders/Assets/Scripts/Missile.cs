using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Missile : Projectile
{

    public Sprite[] animationSprites = new Sprite[3];
    public float animationTime;

    SpriteRenderer spRend;
    int animationFrame;
    private void Awake()
    {
        direction = Vector3.down;
        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = animationSprites[0];
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); //s� fort den krockar med n�got s� ska den f�rsvinna.
    }

    private void AnimateSprite()
    {
        animationFrame++;
        if (animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }
        spRend.sprite = animationSprites[animationFrame];
    }

}