using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthPoints;
    public float speedX;
    public float speedY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
            Destroy(this.gameObject);
    }
}
