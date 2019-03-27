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

    bool isBossDead;

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
        if (boss.GetComponent<Boss>().animator.GetBool("Muffin_Ready"))
            cupcake.SetActive(true);
    }
    void bossDeadCheck()
    {
        if (boss.GetComponent<Boss>().healthPoints <= 0)
        {
            boss.GetComponent<Boss>().isActive = false;
            boss.GetComponent<Boss>().animator.SetTrigger("is_Dead");
            Source.Play();
            isBossDead = true;
        }
    }
}
