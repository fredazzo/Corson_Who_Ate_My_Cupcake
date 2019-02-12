using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMover : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public int damage;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        Vector2 movement = new Vector2(1.0f, 0.0f);

        rb.velocity = movement * speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bound")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
            //collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<Enemy>().healthPoints -= damage;
            if(collision.gameObject.GetComponent<Enemy>().healthPoints <= 0)
                Destroy(collision.gameObject);
        }
    }
}
