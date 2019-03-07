using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;
    public GameObject[] powerUps;
    public AudioSource Source;
    public AudioClip firstClip;
    public AudioClip secondClip;
    public AudioClip thirdClip;

    public Text scoreText;

    public float spawnX;
    public float powerUpSpawnXMax;
    public float powerUpSpawnXMin;
    public float powerUpSpawnYMax;
    public float powerUpSpawnYMin;

    public float crummySpawnMax;
    public float crummySpawnMin;


    public float groundSpawnMax;
    public float groundSpawnMin;

    private Vector2 spawnPoint;

    public float spawnWait;
    private float currentTime = 0f;

    public float powerUpSpawnWait;
    private float powerUpTime = 0f;

    private float musicTimer;
    //public float rateOfDeteriation;
    //public int decreasePercentage;
    //private float lastTime = 0f;   
    //public int barPercentage;
    //public int firstThreshold;

    //public float startWait;

    //public float spawnValueX;
    //public float maxSpawnY;
    //public float minSpawnY;

    //private bool IsPLayerAlive;

    void Start()
    {
        Source = GetComponent<AudioSource>();
        Source.clip = firstClip;
        Source.Play();
    }

    private void Update()
    {
        //musicTimer += Time.deltaTime;
        currentTime += Time.deltaTime;
        powerUpTime += Time.deltaTime;

        //if(musicTimer > 60.0f)
        //{

        //        if (!isSecondPlaying)
        //        {
        //            Source.Stop();
        //            Source.clip = secondClip;
        //            Source.Play();
        //            isSecondPlaying = true;
        //        }

        //}

        //if(musicTimer > 120.0f)
        //{
        //    if (!isThirdPlaying)
        //    {
        //        Source.Stop();
        //        Source.clip = thirdClip;
        //        Source.Play();
        //        isThirdPlaying = true;
        //    }
        //}

        if (currentTime > spawnWait)
            spawnEnemy();

        if (powerUpTime > powerUpSpawnWait)
            spawnPowerUp();
        if (player.GetComponent<PlayerController>().health == 0)
            SceneManager.LoadScene("Death_Scene");
    }

    void spawnEnemy()
    {
        int enemySelection = Random.Range(0, 4);
        if (enemySelection == 0 || enemySelection == 1)
        {
            spawnPoint = new Vector2(spawnX, Random.Range(crummySpawnMin, crummySpawnMax));
            Instantiate(enemies[enemySelection], spawnPoint, Quaternion.identity);
        }
        else if (enemySelection == 2 || enemySelection == 3)
        {
            spawnPoint = new Vector2(spawnX, Random.Range(groundSpawnMin, groundSpawnMax));
            Instantiate(enemies[enemySelection], spawnPoint, Quaternion.identity);
        }
        currentTime = 0;
    }

    void spawnPowerUp()
    {
        int powerUpSelection = Random.Range(0, 2);
        if (powerUpSelection == 0)
        {
            spawnPoint = new Vector2(Random.Range(powerUpSpawnXMin, powerUpSpawnXMax), Random.Range(powerUpSpawnYMin, powerUpSpawnYMax));
            Instantiate(powerUps[powerUpSelection], spawnPoint, Quaternion.identity);
        }
        else if (powerUpSelection == 1)
        {
            spawnPoint = new Vector2(Random.Range(powerUpSpawnXMin, powerUpSpawnXMax), Random.Range(powerUpSpawnYMin, powerUpSpawnYMax));
            Instantiate(powerUps[powerUpSelection], spawnPoint, Quaternion.identity);
        }
        powerUpTime = 0;
    }
}
    