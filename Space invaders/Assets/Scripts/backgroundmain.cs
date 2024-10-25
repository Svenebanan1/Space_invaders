using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class backgroundmain : Projectile
{
    private Vector2 Position;
    public float BackgroundSpeed = 7f;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += BackgroundSpeed * Time.deltaTime * direction;

        Position = transform.position;

        direction = Vector3.down*speed;

        if(Position.y <= -36)
        {
            
            transform.position = new Vector2(0, 36);
        }
       

    }
}
