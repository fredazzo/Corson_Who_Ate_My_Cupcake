using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float crummy_speedX;
    public float crummy_speedY;
    public float wicked_speed;
    public float foul_speed;
    public float swarm_speedX;
    public float swarm_speedY;
    Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (name == "Crummy")
            body.velocity = new Vector2(crummy_speedX, crummy_speedY);
        else if (name == "Wicked")
            body.velocity = new Vector2(wicked_speed, 0);
        else if (name == "Foul")
            body.velocity = new Vector2(foul_speed, 0);
        else if (name == "Swarm")
            body.velocity = new Vector2(swarm_speedX, swarm_speedY);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "bound")
            crummy_speedY = -crummy_speedY;
    }
}