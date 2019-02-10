using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject[] enemies;

    public float spawnWait;
    public float startWait;

    public float spawnValueX;
    public float maxSpawnY;
    public float minSpawnY;

    private bool IsPLayerAlive;

    private void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemy);
            enemies[i] = obj;
            obj.SetActive(false);
        }
        StartCoroutine( SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int j = 0; j < enemies.Length; j++)
            {

                for (int i = 0; i < enemies.Length; i++)
                {
                    Vector2 spawnPosition = new Vector2(spawnValueX, Random.Range(minSpawnY, maxSpawnY));
                    Quaternion spawnRotaion = Quaternion.identity;

                    if (enemies[i].activeInHierarchy == false)
                    {
                        enemies[i].transform.position = spawnPosition;
                        enemies[i].transform.rotation = spawnRotaion;
                        enemies[i].SetActive(true);
                    }
                    yield return new WaitForSeconds(spawnWait);

                }

            }
        }
    }
}
