using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    Image bar;
    public GameObject player;
    public GameObject exit;

    private float decreasedPercentage;
    public float percentageDrop;

    public float barPercentage;

    // Start is called before the first frame update
    void Start()
    {
        //timeLeft = maxTime;
        barPercentage = 1f;
        bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        decreasedPercentage = barPercentage - (percentageDrop * exit.GetComponent<Enemy_Exit_Indicator>().enemiesHit);

        if (exit.GetComponent<Enemy_Exit_Indicator>().enemiesHit > 0)
        {
            bar.fillAmount = decreasedPercentage;
        }

        if (barPercentage > 1.0f)
        {
            barPercentage = 1.0f;
        }

        if(barPercentage < 0f)
        {
            barPercentage = 0f;
        }
    }
    //void CalculateTime()
    //{
    //    barPercentage = timeLeft / maxTime;
    //}


}