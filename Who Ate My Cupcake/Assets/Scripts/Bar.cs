using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    Image bar;
    public GameObject player;

    public float rateOfDeteriation;
    public float decreasePercentage;
    private float lastTime = 0f;
    public float barPercentage;
    public float firstThreshold;
    public float maxTime;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = maxTime;
        barPercentage = 1f;
        bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        lastTime += Time.deltaTime;
        if (lastTime > rateOfDeteriation)
        {
            timeLeft -= .1f;
            CalculateTime();
            bar.fillAmount = barPercentage;
            //barPercentage -= decreasePercentage;
           // bar.fillAmount -= decreasePercentage;
            lastTime = 0f;
        }

        if (barPercentage <= firstThreshold)
        {
            player.GetComponent<PlayerController>().speed = player.GetComponent<PlayerController>().alteredSpeed;
            player.GetComponent<PlayerController>().fireRate = player.GetComponent<PlayerController>().alteredFireRate;

        }
    }
    void CalculateTime()
    {
        barPercentage = timeLeft / maxTime;
    }
}
