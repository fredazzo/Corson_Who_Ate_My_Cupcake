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
    public GameObject funBar;

    public AudioSource Source;
    public AudioClip firstClip;
    public AudioClip secondClip;
    public AudioClip thirdClip;


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



    void Start()
    {
        Source = GetComponent<AudioSource>();
        Source.clip = firstClip;
        Source.Play();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        powerUpTime += Time.deltaTime;

        if (currentTime > spawnWait)
            spawnEnemy();

        if (powerUpTime > powerUpSpawnWait)
            spawnPowerUp();
        if (player.GetComponent<PlayerController>().health == 0)
            SceneManager.LoadScene("Death_Scene");
        if (funBar.GetComponent<Bar>().barPercentage < 0f)
            SceneManager.LoadScene("Death_Scene");
        //Debug.Log(funBar.GetComponent<Bar>().decreasedPercentage);
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

    //public int GetPlayerHealth()
    //{
    //    return player.GetComponent<PlayerController>().health;
    //}
}
    