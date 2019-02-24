using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D body;
    public GameObject bossShot;

    public float bulletSpeedX;
    public float downsideBulletSpeedY;
    public float upsideBulletSpeedY;

    public Vector2 firstBulletSpawn;

    public Vector2 secondBulletSpawn;

    public Vector2 thirdBulletSpawn;

    public Vector3 rotationPoint;
    public float rotationAngle;
    private float Angle;
    private Transform initialHammerTransform;
    GameObject hammer;
    public float healthPoints;
    private bool hasMoved;
    float testTime;
    public float bulletTimer;
    public float bulletTime;
    bool isShot;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        hasMoved = false;
        hammer = transform.Find("Hammer").gameObject;
        isShot = false;
    }

    
    void Update()
    {
        hammer.SetActive(true);
        hammer.transform.RotateAround(rotationPoint, Vector3.forward, rotationAngle);
    }
    void firstSkill()
    {
        Angle = Vector2.Angle(new Vector3(-1, 0, 0), new Vector3(bulletSpeedX, 0, 0));
        GameObject firstShot = Instantiate(bossShot, firstBulletSpawn, Quaternion.Euler(0f, 0f, Angle));
        firstShot.GetComponent<Boss_Projectile>().speedX = bulletSpeedX;
        firstShot.GetComponent<Boss_Projectile>().speedY = 0;

        Angle = Vector2.Angle(new Vector3(-1, 0, 0), new Vector3(bulletSpeedX, downsideBulletSpeedY, 0));
        GameObject secondShot = Instantiate(bossShot, firstBulletSpawn, Quaternion.Euler(0f, 0f, Angle));
        secondShot.GetComponent<Boss_Projectile>().speedX = bulletSpeedX;
        secondShot.GetComponent<Boss_Projectile>().speedY = downsideBulletSpeedY;

        Angle = Vector2.Angle(new Vector3(1, 0, 0), new Vector3(bulletSpeedX, upsideBulletSpeedY, 0));
        GameObject thirdShot = Instantiate(bossShot, firstBulletSpawn, Quaternion.Euler(0f, 0f, Angle));
        thirdShot.GetComponent<Boss_Projectile>().speedX = bulletSpeedX;
        thirdShot.GetComponent<Boss_Projectile>().speedY = upsideBulletSpeedY;
    }

    IEnumerator secondSkill()
    {
        GameObject firstShot = Instantiate(bossShot, firstBulletSpawn, Quaternion.identity);
        firstShot.GetComponent<Boss_Projectile>().speedX = bulletSpeedX;
        firstShot.GetComponent<Boss_Projectile>().speedY = 0;

        yield return new WaitForSeconds(bulletTimer);

        GameObject secondShot = Instantiate(bossShot, secondBulletSpawn, Quaternion.identity);
        secondShot.GetComponent<Boss_Projectile>().speedX = bulletSpeedX;
        secondShot.GetComponent<Boss_Projectile>().speedY = 0;

        yield return new WaitForSeconds(bulletTimer);

        GameObject thirdShot = Instantiate(bossShot, thirdBulletSpawn, Quaternion.identity);
        thirdShot.GetComponent<Boss_Projectile>().speedX = bulletSpeedX;
        thirdShot.GetComponent<Boss_Projectile>().speedY = 0;
    }
}
