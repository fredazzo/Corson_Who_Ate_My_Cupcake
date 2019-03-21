using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crummy_Cotton_Candy : Enemy
{
    Rigidbody2D body;
    Animator anim;
    public GameObject background;
    public float setSpeedX;
    public float lastSpeedY;

    void Start()
    {
        Source = GetComponent<AudioSource>();
        Source.clip = deathSound;
        scoreValue = 100;
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speedX = setSpeedX;
        if (Random.Range(0, 2) == 1)
            speedY = -speedY;
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(speedX, speedY);
        if(anim.GetBool("jumped"))
        {
            speedY = -lastSpeedY;
            speedX = setSpeedX;
            anim.SetBool("jumped", false);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.name == "exit")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.name == "ground")
        {
            lastSpeedY = speedY;
            anim.SetBool("isGrounded", true);
            speedX = - background.GetComponent<background_movement>().speed;
            speedY = 0;
        }        
        else if(other.gameObject.name == "bound")
            speedY = -speedY;
    }
}