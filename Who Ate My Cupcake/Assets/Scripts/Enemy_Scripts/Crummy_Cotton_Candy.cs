using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crummy_Cotton_Candy : Enemy
{
    Rigidbody2D body;
    Animator anim;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (Random.Range(0, 2) == 1)
            speedY = -speedY;
    }

    void Update()
    {
        body.velocity = new Vector2(speedX, speedY);
        if(anim.GetBool("jumped"))
        {
            speedY = 2;
            speedX = -1;
            anim.SetBool("jumped", false);
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "ground")
        {
            //speedY = -speedY;
            anim.SetBool("isGrounded", true);
            speedX = 0;
            speedY = 0;
        }        
        else if(other.gameObject.name == "bound")
            speedY = -speedY;
    }
}