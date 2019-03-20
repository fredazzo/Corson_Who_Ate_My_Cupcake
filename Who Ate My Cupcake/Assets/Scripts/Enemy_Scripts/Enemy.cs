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
        Source = GetComponent<AudioSource>();
            

    }

    // Update is called once per frame
    void Update()
    {
            //Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.name == "exit")
        {
            Destroy(this.gameObject);
        }
    }


}
