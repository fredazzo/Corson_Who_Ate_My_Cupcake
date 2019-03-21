using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthPoints;
    public float speedX;
    public float speedY;
    public int scoreValue;

    public AudioSource Source;
    public AudioClip hitSound;
    public AudioClip deathSound;
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if(healthPoints <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(this.gameObject);
    }
}
