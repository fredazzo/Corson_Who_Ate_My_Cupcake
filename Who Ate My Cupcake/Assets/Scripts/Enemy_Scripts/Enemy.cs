using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthPoints;
    public float speedX;
    public float speedY;
    public bool isActive;
    public GameObject background;

    public AudioSource Source;
    public AudioClip hitSound;
    public AudioClip deathSound;
    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "exit")
        {
            Destroy(this.gameObject);
        }
    }
}
