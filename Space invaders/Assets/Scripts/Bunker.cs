using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bunker : MonoBehaviour
{

    public Sprite Hp1;
    public Sprite Hp2;
    public Sprite Hp3;
    public Sprite Hp4;
    public Sprite Hp0;

    int nrOfHits = 0;
    SpriteRenderer spRend;
    private void Awake()
    {
        spRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Missile") || other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {

            //�ndrar f�rgen beroende p� antal tr�ffar.
            nrOfHits += 1;

        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Beam"))
        {

            //�ndrar f�rgen beroende p� antal tr�ffar.
            nrOfHits += 1;

        }
    }

    private void Update()
    {
        if (nrOfHits == 1)
        {
            spRend.sprite = Hp1;
        }
        else if (nrOfHits == 2)
        {
            spRend.sprite = Hp2;
        }
        else if (nrOfHits == 3)
        {
            spRend.sprite = Hp3;
        }
        else if (nrOfHits == 4)
        {
           
            gameObject.SetActive(false);
            
            spRend.sprite = Hp4;
        }
      
                
           
        


    }

    public void ResetBunker()
    {
        gameObject.SetActive(true);
    }
}

