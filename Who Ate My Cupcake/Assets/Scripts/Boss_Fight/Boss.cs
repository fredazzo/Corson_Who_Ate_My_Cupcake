using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D body;
    public GameObject bossShot;
    public Vector2 firstBulletSpawn;
    public Vector2 firstBulletSpeed;
    public Vector2 secondBulletSpawn;
    public Vector2 secondBulletSpeed;
    public Vector2 thirdBulletSpawn;
    public Vector2 thirdBulletSpeed;
    public Vector3 rotationPoint;
    private float Angle;
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
                Angle = Vector2.Angle(new Vector3(-1, 0, 0), new Vector3(firstBulletSpeed.x, firstBulletSpeed.y, 0));
                GameObject firstShot = Instantiate(bossShot, firstBulletSpawn,Quaternion.Euler(0f,0f, Angle));
                firstShot.GetComponent<Boss_Projectile>().speedX = firstBulletSpeed.x;
                firstShot.GetComponent<Boss_Projectile>().speedY = firstBulletSpeed.y;

                Angle = Vector2.Angle(new Vector3(1, 0, 0), new Vector3(secondBulletSpeed.x, secondBulletSpeed.y, 0));
                GameObject secondShot = Instantiate(bossShot, firstBulletSpawn, Quaternion.Euler(0f, 0f, Angle));
                secondShot.GetComponent<Boss_Projectile>().speedX = secondBulletSpeed.x;
                secondShot.GetComponent<Boss_Projectile>().speedY = secondBulletSpeed.y;

                Angle = Vector2.Angle(new Vector3(-1, 0, 0), new Vector3(thirdBulletSpeed.x, thirdBulletSpeed.y, 0));
                GameObject thirdShot = Instantiate(bossShot, firstBulletSpawn, Quaternion.Euler(0f, 0f, Angle));
                thirdShot.GetComponent<Boss_Projectile>().speedX = thirdBulletSpeed.x;
                thirdShot.GetComponent<Boss_Projectile>().speedY = thirdBulletSpeed.y;

                testTime = 0f;
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
