using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;
    public GameObject bossShot;
    public GameObject player;

    public float bulletSpeedX;
    public float downsideBulletSpeedY;
    public float upsideBulletSpeedY;

    public Vector2 firstBulletSpawn;

    public Vector2 secondBulletSpawn;

    public Vector2 thirdBulletSpawn;

    public float firstBulletTimer;
    public float secondBulletTimer;
    public float bulletTime;

    GameObject hammer;
    public Vector3 rotationPoint;
    public float rotationAngle;
    private float Angle;
    private Transform initialHammerTransform;
    

    GameObject arm;
    public Vector3 armStartPointFromBoss;
    private Vector3 armStartPoint;
    public Vector3 armStopPointFromBoss;
    private Vector3 armStopPoint;

    public float healthPoints;

    private bool armAttack;
    private bool armPositionSet;

    bool isShot;

    public float shotSpawnTime;
    private float time;
    private int randomAttack;
    private bool randomNumber;

    private bool coneShot;
    private bool parallelShot;

    public AudioSource source;
    public AudioClip crossShotSound;
    public AudioClip parallelShotSound;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        arm = transform.Find("Arm").gameObject;
        arm.transform.position = transform.position + armStartPointFromBoss;
        armStartPoint = arm.transform.position;
        armStopPoint = transform.position + armStopPointFromBoss;
        coneShot = false;
        parallelShot = false;

        source = GetComponent<AudioSource>();

    }

    
    void Update()
    {
        time += Time.deltaTime;
        armSkill();
        //if (time > shotSpawnTime)
        //{
        //    if (!randomNumber)
        //    {
        //        randomAttack = Random.Range(1, 3);
        //        randomNumber = true;
        //    }
        //    if (randomAttack == 1)
        //    {
        //        if (!coneShot)
        //        {
        //            animator.SetTrigger("Cone_Started");
        //            coneShot = true;
        //        }

        //        if (animator.GetBool("isShot") == true)
        //        {
        //            crossBullets();
        //            animator.SetBool("isShot", false);
        //        }
        //    }
        //    else if (randomAttack == 2)
        //    {
        //        if (!parallelShot)
        //        {
        //            animator.SetTrigger("Parallel_Started");
        //            parallelShot = true;
        //        }

        //        if (animator.GetBool("isShot") == true)
        //        {
        //            StartCoroutine(parallelBullets());
        //            animator.SetBool("isShot", false);
        //        }
        //    }
        //}
    }
    void crossBullets()
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

        source.clip = crossShotSound;
        source.Play();
        time = 0f;
        coneShot = false;
        randomNumber = false;
    }

    IEnumerator parallelBullets()
    {
        source.clip = parallelShotSound;

        GameObject firstShot = Instantiate(bossShot, firstBulletSpawn, Quaternion.identity);
        firstShot.GetComponent<Boss_Projectile>().speedX = bulletSpeedX;
        firstShot.GetComponent<Boss_Projectile>().speedY = 0;

        source.Play();

        yield return new WaitForSeconds(firstBulletTimer);

        GameObject secondShot = Instantiate(bossShot, secondBulletSpawn, Quaternion.identity);
        secondShot.GetComponent<Boss_Projectile>().speedX = bulletSpeedX;
        secondShot.GetComponent<Boss_Projectile>().speedY = 0;

        source.Play();

        yield return new WaitForSeconds(secondBulletTimer);

        GameObject thirdShot = Instantiate(bossShot, thirdBulletSpawn, Quaternion.identity);
        thirdShot.GetComponent<Boss_Projectile>().speedX = bulletSpeedX;
        thirdShot.GetComponent<Boss_Projectile>().speedY = 0;

        source.Play();

        time = 0f;
        parallelShot = false;
        randomNumber = false;
    }

    /*
    void hammerSkill()
    {
        hammer.SetActive(true);
        hammer.transform.RotateAround(rotationPoint, Vector3.forward, rotationAngle);
    }
    */

    void armSkill()
    {
        if(!armPositionSet)
        {
            arm.transform.position = new Vector3(arm.transform.position.x, player.transform.position.y, 0);
            armPositionSet = true;
        }
            
        arm.SetActive(true);
        if (!armAttack)
            arm.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
        if (arm.transform.position.x > armStopPoint.x)
        {
            armAttack = true;
            arm.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }
        if (arm.transform.position.x < armStartPoint.x)
        {
            arm.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            arm.SetActive(false);
            armPositionSet = false;
        }
    }
}
