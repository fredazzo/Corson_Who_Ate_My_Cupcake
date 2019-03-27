using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] powerUps;
    public GameObject funBar;
    public GameObject overlay;
    public GameObject player;

    public AudioSource Source;
    public AudioClip overlayClip;
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
    public float firstSpawnWait;
    public float secondSpawnWait;
    private float currentTime = 0f;
    private float overlayTimer = 0f;
    public float startGameTimer;

    public float powerUpSpawnWait;
    private float powerUpTime = 0f;
    public float overlayFlashTimer;
    private float overlayBlinkTimer;

    private bool isGameMusicStarted;
    public GameObject musicPlayer;



    void Start()
    {
        isGameMusicStarted = false;
        Source = GetComponent<AudioSource>();
        musicPlayer = GameObject.Find("MUSIC");
        if (musicPlayer == null)
        {
            Source.clip = overlayClip;
            Source.Play();
        }
    }

    private void Update()
    {
        overlayTimer += Time.deltaTime;

        if (overlayTimer < startGameTimer)
        {
            overlayBlinkTimer += Time.deltaTime;
            if (overlayBlinkTimer > overlayFlashTimer)
            {
                if (overlay.activeSelf)
                    overlay.SetActive(false);
                else
                    overlay.SetActive(true);

                overlayBlinkTimer = 0f;
            }
        }

        if (overlayTimer > startGameTimer)
        {
          
            if (!isGameMusicStarted)
            {
                Destroy(musicPlayer = GameObject.Find("MUSIC"));
                Source.clip = firstClip;
                Source.Play();
                isGameMusicStarted = true;
            }
            
            overlay.SetActive(false);
            currentTime += Time.deltaTime;
            powerUpTime += Time.deltaTime;

            if (currentTime > spawnWait)
                spawnEnemy();

            if (powerUpTime > powerUpSpawnWait)
                spawnPowerUp();
            if (PlayerController.health == 0)
                SceneManager.LoadScene("Death_Scene");
            if (funBar.GetComponent<Bar>().barPercentage < 0f)
                SceneManager.LoadScene("Death_Scene");
            //Debug.Log(funBar.GetComponent<Bar>().decreasedPercentage);
        }

        if(player.GetComponent<PlayerController>().firstLevel == false)
        {
            powerUps[0].GetComponent<SpriteRenderer>().sprite = player.GetComponent<PlayerController>().corruptedCoke;
            powerUps[1].GetComponent<SpriteRenderer>().sprite = player.GetComponent<PlayerController>().corruptedCookie;

        }
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

    IEnumerator overlayBlink()
    {
        yield return new WaitForSeconds(overlayFlashTimer);
            overlay.SetActive(false);
        yield return new WaitForSeconds(overlayFlashTimer);
            overlay.SetActive(true);
    }
    //public int GetPlayerHealth()
    //{
    //    return player.GetComponent<PlayerController>().health;
    //}
}
    