using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpTimer : MonoBehaviour
{
    public GameObject player;
    public Image coke;
    public Image cookie;

    public float barPercentage;
    private float rateOfDeteriation;
    private float decreasePercentage;

    private float lastTime = 0f;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        barPercentage = 1f;
        rateOfDeteriation = 1f;
        coke.enabled = false;
        cookie.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player.GetComponent<PlayerController>().poweredUp)
        {
            decreasePercentage = player.GetComponent<PlayerController>().powerUpDecreasePercentage;
            if(player.GetComponent<PlayerController>().cookie == true)
            {
                cookie.enabled = true;
                lastTime += Time.deltaTime;
                if (lastTime > rateOfDeteriation)
                {
                    barPercentage -= decreasePercentage;
                    cookie.fillAmount = barPercentage;

                    lastTime = 0f;
                }

            }
            if (player.GetComponent<PlayerController>().coke == true)
            {
                coke.enabled = true;
                lastTime += Time.deltaTime;
                if (lastTime > rateOfDeteriation)
                {
                    barPercentage -= decreasePercentage;
                    coke.fillAmount = barPercentage;

                    lastTime = 0f;
                }
            }



        }
        else
        {
            cookie.enabled = false;
            coke.enabled = false;
            barPercentage = 1f;
            lastTime = 0f;
        }
    }


}
