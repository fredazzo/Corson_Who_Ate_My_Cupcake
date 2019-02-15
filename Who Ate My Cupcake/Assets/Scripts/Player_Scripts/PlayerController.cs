using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float setSpeed;
    public float speed;
    public float firstAlteredSpeed;
    public float secondAlteredSpeed;
    public float thirdAlteredSpeed;
    public float lastSpeed;
    public int addedDamage;

    public int health;
    public int setDamage;
    public int damage;

    public float addedSpeed;
    public float speedUpDuration;
    public float strengthDuration;
    
    public Transform shotSpawn;
    public GameObject shot;
    public GameObject[] shots;
    public Animator anim;

    public float fireRate;
    public float firstAlteredFireRate;
    public float secondAlteredFireRate;
    public float thirdAlteredFireRate;

    private float nextFire = 0.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // anim = GetComponent<Animator>();
        Debug.Log(health);
        damage = setDamage;
        speed = setSpeed;
        for (int i = 0; i < shots.Length; i++)
        {
            GameObject obj = (GameObject)Instantiate(shot);
            shots[i] = obj;
            shots[i].SetActive(false);
        }
    }

    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            for (int i = 0; i < shots.Length; i++)
            {
                if (shots[i].activeInHierarchy == false)
                {
                    shots[i].transform.position = shotSpawn.transform.position;
                    shots[i].transform.rotation = shotSpawn.transform.rotation;
                    shots[i].GetComponent<ShotMover>().damage = damage;
                    shots[i].SetActive(true);
                    anim.SetTrigger("hasShot");
                    GetComponent<AudioSource>().Play();
                    break;
                }
            }
        }

        if (health == 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Checks and applies physics
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;

        rb.freezeRotation = true;
    }

    // Checks collision between player and enemies
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health--;
            Debug.Log(health);
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "Coke")
        {
            lastSpeed = speed;
            speed += addedSpeed;
            StartCoroutine(speedReset());
        }
        else if(other.gameObject.tag == "Muffin")
        {
            damage += addedDamage;
            StartCoroutine(strengthReset());
        }
    }

    IEnumerator strengthReset()
    {
        yield return new WaitForSeconds(strengthDuration);
        damage = setDamage;
    }

    IEnumerator speedReset()
    {
        yield return new WaitForSeconds(speedUpDuration);
        speed = lastSpeed;
    }
}


