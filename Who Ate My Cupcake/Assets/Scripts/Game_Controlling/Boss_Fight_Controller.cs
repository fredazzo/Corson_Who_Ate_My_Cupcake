using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Fight_Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
      //  player.GetComponent<PlayerController>().health = GetComponent<GameController>().GetPlayerHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().health <= 0)
            SceneManager.LoadScene("Death_Scene");

    }
}
