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

    public Vector2 ConeBulletSpawn;

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

    bool isShot;

    public float attackSpawnTime;
    private float time;
    private int randomAttack;
    private bool randomNumber;

    private bool coneShot;
    private bool parallelShot;

    public AudioSource source;
    public AudioClip crossShotSound;
    public AudioClip parallelShotSound;

    public AudioSource hitSource;
    public AudioClip bossHit;
    public AudioClip bossDeath;

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
    }
    
    void Update()
    {
        time += Time.deltaTime;
        if (time > attackSpawnTime)
        {
            if (!randomNumber)
            {
                randomAttack = Random.Range(1, 4);
                randomNumber = true;
            }
            if (randomAttack == 1)
            {
                if (!coneShot)
                {
                    animator.SetTrigger("Cone_Started");
                    coneShot = true;
                }

                if (animator.GetBool("isShot") == true)
                {
                    crossBullets();
                    animator.SetBool("isShot", false);
                }
            }
            else if (randomAttack == 2)
            {
                if (!parallelShot)
                {
                    animator.SetTrigger("Parallel_Started");
                    parallelShot = true;
                }

                if (animator.GetBool("isShot") == true)
                {
                    StartCoroutine(parallelBullets());
                    animator.SetBool("isShot", false);
                }
            }
            else if (randomAttack == 3)
            {
                armSkill();
            }
        }
    }
    void crossBullets()
    {
       
        Angle = Vector2.Angle(new Vector3(-1, 0, 0), new Vector3(bulletSpeedX, 0, 0));
        GameObject firstShot = Instantiate(bossShot, ConeBulletSpawn, Quaternion.Euler(0f, 0f, Angle));
        firstShot.GetComponent<Boss_Projectile>().speedX = bulletSpeedX;
        firstShot.GetComponent<Boss_Projectile>().speedY = 0;

        Angle = Vector2.Angle(new Vector3(-1, 0, 0), new Vector3(bulletSpeedX, downsideBulletSpeedY, 0));
        GameObject secondShot = Instantiate(bossShot, ConeBulletSpawn, Quaternion.Euler(0f, 0f, Angle));
        secondShot.GetComponent<Boss_Projectile>().speedX = bulletSpeedX;
        secondShot.GetComponent<Boss_Projectile>().speedY = downsideBulletSpeedY;

        Angle = Vector2.Angle(new Vector3(1, 0, 0), new Vector3(bulletSpeedX, upsideBulletSpeedY, 0));
        GameObject thirdShot = Instantiate(bossShot, ConeBulletSpawn, Quaternion.Euler(0f, 0f, Angle));
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
        if (!armAttack)
        {
            arm.transform.position = new Vector3(arm.transform.position.x, player.transform.position.y, 0);
            arm.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);  
            armAttack = true;
            arm.GetComponent<CircleCollider2D>().enabled = true;
        }       
        if (arm.transform.position.x > armStopPoint.x)
        {
            arm.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
            arm.GetComponent<CircleCollider2D>().enabled = false; ;
        }
            
        else if (arm.transform.position.x < armStartPoint.x)
        {
            arm.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            arm.transform.position = new Vector3(arm.transform.position.x + 1, player.transform.position.y, 0);
            randomNumber = false;
            armAttack = false;
            time = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Shot")
        {
            hitSource.clip = bossHit;
            hitSource.Play();
            healthPoints--;
            other.gameObject.SetActive(false);
        }
            
    }
}
