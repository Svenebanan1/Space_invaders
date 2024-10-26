using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class healthbar : MonoBehaviour
{

    public float healthbarspeed = 10f;
    public float boss;
    public Vector2 target;
    public Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(0f, 0f);
        position = gameObject.transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        float step = healthbarspeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, healthbarspeed);

    }
}
