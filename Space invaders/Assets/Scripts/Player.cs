using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : Laser
{
    [SerializeField] private AudioSource lasersound;

    public Laser laserPrefab;
    public Laser laser;
    float Playerspeed = 10f;
    public DateTime? fastshottime = null;
    public DateTime? stoptime = null;

    public Sprite leftTurn;
    public Sprite rightTurn;
    public Sprite[] playeranimationSprites = new Sprite[3];
    public float playeranimationTime;
    int playeranimationFrame;
    SpriteRenderer playerspRend;

    private AudioSource audioSource;

    Vector3 laserspawn;

    private void Start()
    {
        playerspRend = GetComponent<SpriteRenderer>();
        playerspRend.sprite = playeranimationSprites[0];

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        laserspawn = transform.position + new Vector3(0f, 1.5f, 0);
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerspRend.sprite = leftTurn;
            position.x -= Playerspeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerspRend.sprite = rightTurn;
            position.x += Playerspeed * Time.deltaTime;
        }
        else
        {
            playeranimationFrame++;
            if (playeranimationFrame >= playeranimationSprites.Length)
            {
                playeranimationFrame = 0;
            }
            playerspRend.sprite = playeranimationSprites[playeranimationFrame];
        }


        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);

        transform.position = position;

        if (fastshottime.HasValue)
        {
            if (fastshottime.Value < DateTime.Now)
            {
                fastshottime = null;
            }
        }

        if (stoptime.HasValue)
        {
            if (stoptime.Value < DateTime.Now)
            {
                stoptime = null;
            }
        }

        if (stoptime.HasValue)
        {
            Time.timeScale = 0.5f;
            speed = 20f;
            
        }
        else
        {
            Time.timeScale = 1f;
            speed = 10f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (laser == null || fastshottime.HasValue) )
        {
            audioSource.Play();
            laser = Instantiate(laserPrefab, laserspawn, Quaternion.identity);

        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Missile") || collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            GameManager.Instance.OnPlayerKilled(this);
        }

       
           
         if (collision.gameObject.tag == "Fastershoting")
         {
            fastshottime = DateTime.Now.AddSeconds(3);
         }

         if (collision.gameObject.tag == "Stop time")
        {
            stoptime = DateTime.Now.AddSeconds(5);
        }
       

    }



   
}


