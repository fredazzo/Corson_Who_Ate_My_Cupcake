using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_up : MonoBehaviour
{
    Rigidbody2D body;
    public GameObject background;
    public float speedY;
    private float speedX;
    public float powerUpDuration;

    public float barIncrease;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speedX = -background.GetComponent<background_movement>().speed;

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        body.velocity = new Vector2(speedX, speedY);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
         
            Destroy(this.gameObject);
           
        }
        if (other.gameObject.name == "exit")
            Destroy(this.gameObject);
    }
}
