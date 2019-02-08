using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health;

    public Transform shotSpawn;
    public GameObject[] shots;

    public float fireRate;
    private float nextFire = 0.0f;

    private Rigidbody2D rb;

    private List<GameObject> totalShots;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(health);
        for (int i = 0; i < shots.Length; i++)
        {
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
                if (shots[i].activeSelf == false)
                {
                    // shots[i].SetActive(true);
                    Instantiate(shots[i], shotSpawn.position, shotSpawn.rotation);
                    GetComponent<AudioSource>().Play();
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
        if (other.gameObject.tag == "Enemy")
        {
            health--;
            Debug.Log(health);
            Destroy(other.gameObject);
        }
    }
}


