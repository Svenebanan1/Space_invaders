using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Boss : MonoBehaviour
{
  


    public float life = 10;
    float speed = 5f;
    float cycleTime = 0.2f;

    Vector2 leftDestination;
    Vector2 rightDestination;
    int direction = -1;
    bool isVisible;


    public Sprite[] animationSprites = new Sprite[9];
    public float animationTime;
    int animationFrame;
    SpriteRenderer spRend;


    void Start()
    {

        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = animationSprites[0];
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        //positionen d�r den kommer stanna utanf�r sk�rmen.
        leftDestination = new Vector2(leftEdge.x - 1f, transform.position.y);
        rightDestination = new Vector2(rightEdge.x + 1f, transform.position.y);

        SetInvisible();
    }

    public int GetBossCount()
    {
        int nr = 0;

        foreach (Transform boss in transform)
        {
            if (boss.gameObject.activeSelf)
                nr++;
        }
        return nr;
    }
    void Update()
    {
        if (!isVisible) //�r den inte synlig s� ska den ej r�ra sig.
        {
            return;
        }

        if (direction == 1)
        {
            //r�r sig �t h�ger
            transform.position += speed * Time.deltaTime * Vector3.right;

            if (transform.position.x >= rightDestination.x)
            {
                SetInvisible();
            }
        }
        else
        {
            //r�r sig �t v�nster
            transform.position += speed * Time.deltaTime * Vector3.left;

            if (transform.position.x <= leftDestination.x)
            {
                SetInvisible();
            }
        }

        if (life <= 0)
        {
            GameManagerboss.Instance.OnBossKilled(this);
        }
    }


    //flyttar den till en plast precis utanf�r scenen.
    void SetInvisible()
    {
        isVisible = false;

        if (direction == 1)
        {
            transform.position = rightDestination;
        }
        else
        {
            transform.position = leftDestination;
        }

        Invoke(nameof(SetVisible), cycleTime); //anropar SetVisible efter ett visst antal sekunder
    }

    void SetVisible()
    {
        direction *= -1; //�ndrar riktningen

        isVisible = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
           life = life - 1;
        }
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
