using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    Image bar;
    public GameObject player;
    public GameObject exit;

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

        bar.fillAmount = barPercentage;
    }
    //void CalculateTime()
    //{
    //    barPercentage = timeLeft / maxTime;
    //}


}