using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject gameController;
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
    public float powerUpDuration;
    public float powerUpDecreasePercentage;
    //public float speedUpDuration;
    //public float strengthDuration;
    
    public Transform shotSpawn;
    public GameObject shot;
    public GameObject[] shots;
    public Animator anim;
    public GameObject bar;

     public AudioSource source;
    public AudioClip shootingSound;
    public AudioClip pop;
    public AudioSource PowerUpsource;
    public AudioClip CokeSound;
    public AudioClip CookieSound;
   



    public float fireRate;
    public float firstAlteredFireRate;
    public float secondAlteredFireRate;
    public float thirdAlteredFireRate;

    private float nextFire = 0.0f;

    private Rigidbody2D rb;

    public bool poweredUp;
    public bool cookie;
    public bool coke;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // anim = GetComponent<Animator>();
        damage = setDamage;
        speed = setSpeed;
        for (int i = 0; i < shots.Length; i++)
        {
            GameObject obj = (GameObject)Instantiate(shot);
            shots[i] = obj;
            shots[i].SetActive(false);
        }
        poweredUp = false;
        cookie = false;
        coke = false;
        source = GetComponent<AudioSource>();
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
                    source.clip = shootingSound;
                    source.Play();
                    break;
                }
            }
        }

        if (health == 0)
        {
            gameObject.SetActive(false);
        }

        if (health > 5)
        {
            health = 5;
        }
        if (health < 0)
        {
            health = 0;
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
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss_Shot")
        {
            health--;
            source.clip = pop;
            source.Play();
            Debug.Log(health);
            Destroy(other.gameObject);
        }
        if(other.gameObject.GetComponent<CircleCollider2D>())
        {
            health--;
            source.clip = pop;
            source.Play();
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }
        if(other.gameObject.tag == "Mega_Cupcake")
        {
            SceneManager.LoadScene("CutScene");
        }

        if (other.gameObject.tag == "Coke")
        {
            PowerUpsource.clip = CokeSound;
            PowerUpsource.Play();

       
            poweredUp = true;
            coke = true;
            powerUpDuration = other.gameObject.GetComponent<power_up>().powerUpDuration;
            powerUpDecreasePercentage = 1f / powerUpDuration;
       //     lastSpeed = speed;
            speed += addedSpeed;
            StartCoroutine(reset());
        }
        else if(other.gameObject.tag == "Muffin")
        {
            PowerUpsource.clip = CookieSound;
            PowerUpsource.Play();

            poweredUp = true;
            cookie = true;
            powerUpDuration = other.gameObject.GetComponent<power_up>().powerUpDuration;
            powerUpDecreasePercentage = 1f / powerUpDuration;
            damage += addedDamage;
            StartCoroutine(reset());
        }
        else if(other.gameObject.tag == "Health")
        {
            health += 1;
        }
        else if (other.gameObject.tag == "Bar Up")
        {
            bar.GetComponent<Bar>().barPercentage += other.gameObject.GetComponent<power_up>().barIncrease;
        }
    }

    IEnumerator reset()
    {
        yield return new WaitForSeconds(powerUpDuration);
        damage = setDamage;
        speed = setSpeed;
        poweredUp = false;
        cookie = false;
        coke = false;

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "First_Song_Change")
        {
            gameController.GetComponent<GameController>().Source.Stop();
            gameController.GetComponent<GameController>().Source.clip = gameController.GetComponent<GameController>().secondClip;
            gameController.GetComponent<GameController>().Source.Play();
        }
        if (other.gameObject.name == "Second_Song_Change")
        {
            gameController.GetComponent<GameController>().Source.Stop();
            gameController.GetComponent<GameController>().Source.clip = gameController.GetComponent<GameController>().thirdClip;
            gameController.GetComponent<GameController>().Source.Play();
        }
        if (other.gameObject.tag == "Boss_Boundary")
            SceneManager.LoadScene("Boss_Fight");
    }
}


