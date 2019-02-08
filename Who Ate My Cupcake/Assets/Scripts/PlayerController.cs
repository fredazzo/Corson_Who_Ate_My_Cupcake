using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Boundaries
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public Boundaries boundaries;
    public float speed;
    public int health;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire = 0.0f;

    private Rigidbody2D rb;

    private List<GameObject> totalShots;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(health);

    }


    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GameObject shotFired = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            shotFired.gameObject.SetActive(true);

            GetComponent<AudioSource>().Play();
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

        rb.position = new Vector2
            (Mathf.Clamp(rb.position.x, boundaries.xMin, boundaries.xMax),
            Mathf.Clamp(rb.position.y, boundaries.yMin, boundaries.yMax));
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


