using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShotMover : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public int damage;

    public GameObject gameController;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(1.0f, 0.0f);

        rb.velocity = movement * speed;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bound")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
            collision.gameObject.GetComponent<Enemy>().healthPoints -= damage;

            //if (collision.gameObject.GetComponent<Enemy>().healthPoints > 0)
            //{
            //    collision.gameObject.GetComponent<Enemy>().Source.Play();
            //}

            if (collision.gameObject.GetComponent<Enemy>().healthPoints <= 0)
            {
                //collision.gameObject.GetComponent<Enemy>().Source.clip = collision.gameObject.GetComponent<Enemy>().deathSound;
                //collision.gameObject.GetComponent<Enemy>().Source.Play();
                Destroy(collision.gameObject);
            }
        }
        if(collision.gameObject.tag == "Play_Button")
        {
            SceneManager.LoadScene("Peace_Scene");
        }
    }
}
