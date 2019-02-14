using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;
    public int totalScore;
    string scoreString;

    public Text scoreText;

    public float spawnX;

    public float crummySpawnMax;
    public float crummySpawnMin;

    public float groundSpawnMax;
    public float groundSpawnMin;

    private Vector2 spawnPoint;

    public float spawnWait;
    private float currentTime = 0f;

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

    private void Start()
    {
        //barPercentage = 100;

    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > spawnWait)
            spawnEnemy();

        scoreString = totalScore.ToString();
        scoreText.text = scoreString;
        Debug.Log(totalScore);
        //lastTime += Time.deltaTime;
        //if (lastTime > rateOfDeteriation)
        //{
        //    barPercentage -= decreasePercentage;
        //    lastTime = 0f;
        //}
        //Debug.Log(barPercentage);

        //if(barPercentage <= firstThreshold)
        //{
        //    player.GetComponent<PlayerController>().speed = player.GetComponent<PlayerController>().alteredSpeed;
        //    player.GetComponent<PlayerController>().fireRate = player.GetComponent<PlayerController>().alteredFireRate;
        //}
    }

    void spawnEnemy()
    {
        int enemySelection = Random.Range(0, 4);
        if (enemySelection == 0 || enemySelection == 1)
        {
            spawnPoint = new Vector2(spawnX, Random.Range(crummySpawnMin, crummySpawnMax));
            Instantiate(enemies[enemySelection], spawnPoint, Quaternion.identity);
        }
        else if(enemySelection == 2 || enemySelection == 3)
        {
            spawnPoint = new Vector2(spawnX, Random.Range(groundSpawnMin, groundSpawnMax));
            Instantiate(enemies[enemySelection], spawnPoint, Quaternion.identity);
        }
        currentTime = 0;
    }
}



//    private void Start()
//    {
//        for (int i = 0; i < enemies.Length; i++)
//        {
//            GameObject obj = (GameObject)Instantiate(enemy);
//            enemies[i] = obj;
//            obj.SetActive(false);
//        }
//        StartCoroutine( SpawnWaves());
//    }

//    IEnumerator SpawnWaves()
//    {

//        yield return new WaitForSeconds(startWait);

//        while (true)
//        {
//            for (int j = 0; j < enemies.Length; j++)
//            {

//                for (int i = 0; i < enemies.Length; i++)
//                {
//                    Vector2 spawnPosition = new Vector2(spawnValueX, Random.Range(minSpawnY, maxSpawnY));
//                    Quaternion spawnRotaion = Quaternion.identity;

//                    if (enemies[i].activeInHierarchy == false)
//                    {
//                        enemies[i].transform.position = spawnPosition;
//                        enemies[i].transform.rotation = spawnRotaion;
//                        enemies[i].SetActive(true);
//                    }
//                    yield return new WaitForSeconds(spawnWait);

//                }

//            }
//        }
//    }
//}
