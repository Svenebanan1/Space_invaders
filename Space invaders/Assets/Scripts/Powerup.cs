using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

 public class Powerup : Projectile  
{
    public float Speed = 10f;
   

    SpriteRenderer spRend;
  
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

    }

    



}
