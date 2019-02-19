using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D body;
    public GameObject bossShot;
    public Vector2 firstBulletSpawn;
    public Vector2 secondBulletSpawn;
    public Vector2 thirdBulletSpawn;
    public float healthPoints;
    private bool hasMoved;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        hasMoved = false;
    }

    
    void Update()
    {
        if(!hasMoved)
        {
            if (Input.GetButtonDown("First_Skill"))
            {
                GameObject firstShot = Instantiate(bossShot, firstBulletSpawn, Quaternion.identity);
                GameObject secondShot = Instantiate(bossShot, firstBulletSpawn, Quaternion.identity);
                GameObject thirdShot = Instantiate(bossShot, firstBulletSpawn, Quaternion.identity);
            }
            if (Input.GetButtonDown("Second_Skill"))
                Debug.Log("Second skill used");
            if (Input.GetButtonDown("Third_Skill"))
                Debug.Log("Third skill used");
            if (Input.GetButtonDown("Fourth_Skill"))
                Debug.Log("Fourth skill used");
        }
    }
}
