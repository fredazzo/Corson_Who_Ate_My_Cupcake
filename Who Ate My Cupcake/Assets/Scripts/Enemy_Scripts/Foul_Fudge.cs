using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foul_Fudge : Enemy
{
    Rigidbody2D body;
    void Start()
    {
        Source = GetComponent<AudioSource>();
       
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(speedX, speedY);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Shot")
        {
            Source.clip = hitSound;
            Source.Play();
        
        }
        if (other.gameObject.name == "exit")
        {
            Destroy(this.gameObject);
        }
    }
}
