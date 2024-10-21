using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Missile : Projectile
{
    [SerializeField] private AudioSource Missilesound;

    private AudioSource audioSource;



    float Speed = 4f;

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
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }

    void Update()
    {

        transform.position += Speed * Time.deltaTime * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Bunker"))
        {

            Destroy(gameObject);
            audioSource.Play();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Boundary"))
        {

            Destroy(gameObject);

        }
        //s� fort den krockar med n�got s� ska den f�rsvinna.

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