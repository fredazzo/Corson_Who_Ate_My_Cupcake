using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthPoints;
    public float speedX;
    public float speedY;
    public int scoreValue;
    void Start()
    {
        scoreValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
