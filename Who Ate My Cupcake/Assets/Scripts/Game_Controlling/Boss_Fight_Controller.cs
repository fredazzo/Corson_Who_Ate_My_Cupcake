using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Fight_Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public GameObject cupcake;

    AudioSource Source;

    private bool isBossDead;

    void Start()
    {
        isBossDead = false;
        Source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlayerController.health <= 0)
            SceneManager.LoadScene("Death_Scene");
        if (!isBossDead)
        {
            bossDeadCheck();
        } 
    }
    void bossDeadCheck()
    {
        if (boss.GetComponent<Boss>().healthPoints == 0)
        {
            Source.Play();
            Destroy(boss);
            cupcake.SetActive(true);
            isBossDead = true;
        }
    }
}
