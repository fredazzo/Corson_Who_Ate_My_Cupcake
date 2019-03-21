using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wricked_Wrapper : Enemy
{
    Rigidbody2D body;
    GameObject player;
    Animator anim;
    Vector2 velocity;
    void Start()
    {
        isActive = true;
        player = GameObject.Find("Player");
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        velocity = new Vector2(speedX, speedY);
    }

    void Update()
    {
        if (healthPoints == 0)
        {
            if (isActive)
            {
                Source.clip = deathSound;
                Source.Play();
            }               
            isActive = false;
            if (player.GetComponent<PlayerController>().firstLevel)
                anim.SetTrigger("First_Death");
            else
                anim.SetTrigger("Second_Death");
            velocity = new Vector2(-background.GetComponent<background_movement>().speed, 0f);
        }
        if (!isActive)
            GetComponent<BoxCollider2D>().isTrigger = true;
    }


    void FixedUpdate()
    {
        body.velocity = velocity;
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
