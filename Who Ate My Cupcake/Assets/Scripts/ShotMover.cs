using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMover : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        Vector2 movement = new Vector2(1.0f, 0.0f);

        rb.velocity = movement * speed;

    }

}
