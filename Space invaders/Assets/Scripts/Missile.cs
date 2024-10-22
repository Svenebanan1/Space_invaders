using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Missile : Projectile
{
   




    float Speed = 4f;

    
    int animationFrame;
    private void Awake()
    {
        direction = Vector3.down;
       
    }

    private void Start()
    {
      

       
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