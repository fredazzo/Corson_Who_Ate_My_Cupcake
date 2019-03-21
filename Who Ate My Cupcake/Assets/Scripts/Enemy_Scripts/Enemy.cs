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
        isActive = true;
    }

    public void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "exit")
        {
            Destroy(this.gameObject);
        }
    }
}
