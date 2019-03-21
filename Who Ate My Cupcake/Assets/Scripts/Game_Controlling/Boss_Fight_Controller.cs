using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Fight_Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public GameObject cupcake;

    private bool isBossDead;

    // Start is called before the first frame update
    void Start()
    {
        isBossDead = false;
      //  player.GetComponent<PlayerController>().health = GetComponent<GameController>().GetPlayerHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().health <= 0)
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
            Destroy(boss);
            cupcake.SetActive(true);
            isBossDead = true;
        }
    }
}
