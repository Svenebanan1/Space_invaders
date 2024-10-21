using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource lasersound;

    public Laser laserPrefab;
   public Laser laser;
    float Playerspeed = 10f;

    public Sprite leftTurn;
    public Sprite rightTurn;
    public Sprite[] animationSprites = new Sprite[3];
    public float animationTime;
    int animationFrame;
    SpriteRenderer spRend;

    private AudioSource audioSource;

    Vector3 laserspawn;

    private void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = animationSprites[0];

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       

        laserspawn = transform.position + new Vector3(0f, 1.5f, 0);
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spRend.sprite = leftTurn;
            position.x -= Playerspeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            spRend.sprite = rightTurn;
            position.x += Playerspeed * Time.deltaTime;
        }
        else
        {
            animationFrame++;
            if (animationFrame >= animationSprites.Length)
            {
                animationFrame = 0;
            }
            spRend.sprite = animationSprites[animationFrame];
        }
       

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);

        transform.position = position;



            if (Input.GetKeyDown(KeyCode.Space) && laser == null)
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

        if (collision.gameObject.layer == LayerMask.NameToLayer("Powerups"))
        {
          


        }

    }



   
}


