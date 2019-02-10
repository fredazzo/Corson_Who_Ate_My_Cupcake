using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health;
    
    public Transform shotSpawn;
    public GameObject shot;
    public GameObject[] shots;

    public float fireRate;
    private float nextFire = 0.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(health);

        for (int i = 0; i < shots.Length; i++)
        {
            GameObject obj = (GameObject)Instantiate(shot);
            shots[i] = obj;
            shots[i].SetActive(false);
        }
    }

    void Update()
    {


        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            for (int i = 0; i < shots.Length; i++)
            {
                if (shots[i].activeInHierarchy == false)
                {
                    shots[i].transform.position = shotSpawn.transform.position;
                    shots[i].transform.rotation = shotSpawn.transform.rotation;
                    shots[i].SetActive(true);
                    GetComponent<AudioSource>().Play();
                    break;
                }

            }
        }


        if (health == 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Checks and applies physics
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;

        rb.freezeRotation = true;
    }

    // Checks collision between player and enemies
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Shot")
        {
            health--;
            Debug.Log(health);
            other.gameObject.SetActive(false);
        }

    }

}


