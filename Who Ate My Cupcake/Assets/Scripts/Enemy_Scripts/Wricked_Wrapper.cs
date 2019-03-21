using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wricked_Wrapper : Enemy
{
    Rigidbody2D body;
    void Start()
    {
        Source = GetComponent<AudioSource>();

        body = GetComponent<Rigidbody2D>();
        scoreValue = 100;
    }
    private void Update()
    {
        if (healthPoints <= 0)
        {
            Source.clip = deathSound;
            Source.Play();

            Destroy(this.gameObject);

        }
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
    }
}
