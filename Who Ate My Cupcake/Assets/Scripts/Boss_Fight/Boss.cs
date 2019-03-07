using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;
    public GameObject bossShot;
    Animator animator;

    public float bulletSpeedX;
    public float downsideBulletSpeedY;
    public float upsideBulletSpeedY;

    public Vector2 firstBulletSpawn;

    public Vector2 secondBulletSpawn;

    public Vector2 thirdBulletSpawn;

    public float bulletTimer;
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

    private float testTime;
    bool triggered;
   
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hammer = transform.Find("Hammer").gameObject;
        arm = transform.Find("Arm").gameObject;
        arm.transform.position = transform.position + armStartPointFromBoss;
        armStartPoint = arm.transform.position;
        armStopPoint = transform.position + armStopPointFromBoss;
        triggered = false;
    }

    
    void Update()
    {
        testTime += Time.deltaTime;

        if(testTime > 5f)
        {
            animator.SetTrigger("Cone_Started");
            animator.SetTrigger("Cone_Shot");
            testTime = 0f;
        }
        if(animator.GetBool("isShot") == true)
        {
            crossBullets();
            animator.SetBool("isShot", false);
        }

        //if (testTime > 5f)
        //{
            //Cross Shot
            {
                //if (!triggered)
                //{
                //    animator.SetTrigger("Cone");
                //    triggered = true;
                //}
                //if (animator.GetBool("is_Shot"))
                //{
                //    crossBullets();
                //    testTime = 0f;
                //    triggered = false;
                //}
            }

            //Parallel Shot
            {
                //if (!triggered)
                //{
                //    animator.SetTrigger("Parallel");
                //    triggered = true;
                //}
                //if (animator.GetBool("is_Shot"))
                //{
                //    StartCoroutine(parallelBullets());
                //    testTime = 0f;
                //    triggered = false;
                //}
            }

            //Slap Skill
            armSkill();
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

        animator.SetBool("is_Shot", false);
    }

    IEnumerator parallelBullets()
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

    void hammerSkill()
    {
        hammer.SetActive(true);
        hammer.transform.RotateAround(rotationPoint, Vector3.forward, rotationAngle);
    }

    void armSkill()
    {
        arm.SetActive(true);
        if (!armAttack)
            arm.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        if (arm.transform.position.x > armStopPoint.x)
        {
            armAttack = true;
            arm.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
            if (arm.transform.position.x < armStartPoint.x)
            {
                Debug.Log("sa");
                arm.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                arm.SetActive(false);
            }
        }
    }
}
