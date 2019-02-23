using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Projectile : MonoBehaviour
{
    public float speedX, speedY;
    Rigidbody2D body;
    public int damage;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(speedX, speedY);
        body.velocity = movement;
        //transform.Rotate(0, 0, speedY);
    }
}
