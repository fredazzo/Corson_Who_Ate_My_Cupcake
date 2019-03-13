using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wricked_Wrapper : Enemy
{
    Rigidbody2D body;
    void Start()
    {
        Source = GetComponent<AudioSource>();
        Source.clip = hitSound;
        body = GetComponent<Rigidbody2D>();
        scoreValue = 100;
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(speedX, speedY);
    }
}
