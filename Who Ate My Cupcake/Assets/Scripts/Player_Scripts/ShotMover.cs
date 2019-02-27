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
            //collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<Enemy>().healthPoints -= damage;
            if (collision.gameObject.GetComponent<Enemy>().healthPoints <= 0)
            {
                //Debug.Log(gameController.GetComponent<GameController>().sa);
                //Debug.Log("++++++++++++++");
                //Debug.Log(collision.gameObject.GetComponent<Enemy>().scoreValue);
                //gameController.GetComponent<GameController>().setTotalScore(collision.gameObject.GetComponent<Enemy>().scoreValue);
                //gameController.gameObject.GetComponent<GameController>().totalScore += collision.gameObject.GetComponent<Enemy>().scoreValue;
                Destroy(collision.gameObject);
            }
        }
        if(collision.gameObject.tag == "Play_Button")
        {
            SceneManager.LoadScene("Peace_Scene");
        }
    }
}
