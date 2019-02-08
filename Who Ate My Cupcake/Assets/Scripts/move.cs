using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Boundaries
{
    public float xMin, xMax, yMin, yMax;
}

public class move : MonoBehaviour
{
    public Boundaries boundaries;
    public float speed;
    public int health;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire = 0.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Debug.Log(health);
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    // Checks and applies physics
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (Mathf.Clamp(rb.position.x, boundaries.xMin, boundaries.xMax),
            Mathf.Clamp(rb.position.y, boundaries.yMin, boundaries.yMax),
            0.0f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health--;
            Destroy(other.gameObject);
        }
    }
}


