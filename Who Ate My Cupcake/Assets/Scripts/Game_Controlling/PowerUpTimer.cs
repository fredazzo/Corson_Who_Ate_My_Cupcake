using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpTimer : MonoBehaviour
{
    Image bar;
    public GameObject player;
    public Image coke;
    public Image muffin;

    public float barPercentage;
    private float rateOfDeteriation;
    private float decreasePercentage;

    private float lastTime = 0f;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        barPercentage = 1f;
        bar = GetComponent<Image>();
        rateOfDeteriation = 1f;
        bar.enabled = false;
        muffin.enabled = false;
        coke.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (player.GetComponent<PlayerController>().poweredUp)
        {
            bar.enabled = true;
            decreasePercentage = player.GetComponent<PlayerController>().powerUpDecreasePercentage;
            if(player.GetComponent<PlayerController>().muffin == true)
            {
                muffin.enabled = true;
            }
            if (player.GetComponent<PlayerController>().coke == true)
            {
                coke.enabled = true;
            }

            lastTime += Time.deltaTime;
            if (lastTime > rateOfDeteriation)
            {
                barPercentage -= decreasePercentage;
                bar.fillAmount = barPercentage;

                lastTime = 0f;
            }

        }
        else
        {
            bar.enabled = false;
            muffin.enabled = false;
            coke.enabled = false;
            barPercentage = 1f;
            lastTime = 0f;
        }
    }


}
