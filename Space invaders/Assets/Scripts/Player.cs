using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public Laser laserPrefab;
   public Laser laser;
    float Playerspeed = 10f;
    float speed = 10f;
    public float time = 0f;

    int Lasercount = 0;

    

    Vector3 laserspawn;

    // Update is called once per frame
    void Update()
    {
        laserspawn = transform.position + new Vector3(0f, 1.5f, 0);
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= Playerspeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += Playerspeed * Time.deltaTime;
        }

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);

        transform.position = position;



            if (Input.GetKeyDown(KeyCode.Space) && laser == null)
            {
               
                laser = Instantiate(laserPrefab, laserspawn, Quaternion.identity);
                
            }
            

        
        if(time > 0)
        {
            speed = 25;
            time -= Time.deltaTime;
            
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
            time += 2f;
           


        }

    }
}


