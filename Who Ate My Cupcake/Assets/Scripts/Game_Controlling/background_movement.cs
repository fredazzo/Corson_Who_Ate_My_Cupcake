using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_movement : MonoBehaviour
{
    Rigidbody2D body;
    public float speed;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.velocity = new Vector2(-1 * speed, 0);
    }
}
