using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Exit_Indicator : MonoBehaviour
{ 
    public AudioSource source;
    public GameObject bar;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
       // enemiesHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            source.Play();
            if(other.gameObject.GetComponent<Enemy>().isActive)
                bar.GetComponent<Bar>().barPercentage -= bar.GetComponent<Bar>().percentageDrop;
            PlayerController.shouldShake = true;
        }
    }
}
