using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;

    public float spawnX;

    public float crummySpawnMax;
    public float crummySpawnMin;

    public float groundSpawnMax;
    public float groundSpawnMin;

    private Vector2 spawnPoint;

    public float spawnWait;
    private float currentTime = 0f;
    //public float startWait;

    //public float spawnValueX;
    //public float maxSpawnY;
    //public float minSpawnY;

    //private bool IsPLayerAlive;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > spawnWait)
            spawnEnemy();
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
        Debug.Log(enemySelection);
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
