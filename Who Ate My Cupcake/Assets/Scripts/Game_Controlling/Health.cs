using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    int healthPoints;
    public GameObject player;

    public Image health1;
    public Image health2;
    public Image health3;
    public Image health4;
    public Image health5;

    // Update is called once per frame
    void Update()
    {
        healthPoints = player.GetComponent<PlayerController>().health;

        if (healthPoints <= 4)
        {
            health5.enabled = false;
         //  Debug.Log("health5 disabled");
        }
        if (healthPoints <= 3)
        {
            health4.enabled = false;

            // Debug.Log("health4 disabled");
        }
        if (healthPoints <= 2)
        {
            health3.enabled = false;

            //  Debug.Log("health3 disabled");
        }
        if (healthPoints <= 1)
        {
            health2.enabled = false;

            //  Debug.Log("health2 disabled");
        }
        if (healthPoints <= 0)
        {
            health1.enabled = false;

            // Debug.Log("health1 disabled");
        }
    }
}
