using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foul_Fudge : Enemy
{
    Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(speedX, speedY);
    }
}
