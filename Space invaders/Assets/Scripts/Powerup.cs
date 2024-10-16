using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

 public class Powerup : Projectile
{
    public float Speed = 10f;
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
        transform.position += Speed * Time.deltaTime * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); 
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
