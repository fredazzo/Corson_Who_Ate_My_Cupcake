using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foul_Fudge : Enemy
{
    Rigidbody2D body;
    GameObject player;
    Animator anim;
    Vector2 velocity;
    void Start()
    {
        isActive = true;
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (healthPoints == 0)
        {
            isActive = false;
            Source.clip = deathSound;
            Source.Play();
            if (player.GetComponent<PlayerController>().firstLevel)
                anim.SetTrigger("First_Death");
            else
                anim.SetTrigger("Second_Death");
            velocity = new Vector2(0f, 0f);
        }
        if (anim.GetBool("is_Dead"))
            Destroy(this.gameObject);
        if (!isActive)
            GetComponent<BoxCollider2D>().isTrigger = true;
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
