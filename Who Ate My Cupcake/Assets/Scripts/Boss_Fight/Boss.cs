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
    public Vector3 rotationPoint;
    private Transform initialHammerTransform;
    GameObject hammer;
    public float healthPoints;
    private bool hasMoved;
    float testTime;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        hasMoved = false;
        hammer = transform.Find("Hammer").gameObject;
    }

    
    void Update()
    {
        testTime += Time.deltaTime;
        if(!hasMoved)
        {
            if (testTime > 5f)
            {
                GameObject hammer = transform.Find("Hammer").gameObject;
                hammer.SetActive(true);
                hammer.transform.RotateAround(rotationPoint, new Vector3(0,0,1), 20 * Time.deltaTime);
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
