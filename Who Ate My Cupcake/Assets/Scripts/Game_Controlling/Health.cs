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

    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public Animator anim5;

    private void Start()
    {
        anim5 = health5.GetComponent<Animator>();
        anim4 = health4.GetComponent<Animator>();
        anim3 = health3.GetComponent<Animator>();
        anim2 = health2.GetComponent<Animator>();
        anim1 = health1.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        healthPoints = player.GetComponent<PlayerController>().health;

        if(healthPoints > 4)
        {
            health5.enabled = true;

        }
        if (healthPoints <= 4)
        {
            anim5.SetTrigger("popped");

        }
        if (healthPoints <= 3)
        {
            anim4.SetTrigger("popped");


        }
        if (healthPoints <= 2)
        {
            anim3.SetTrigger("popped");


        }
        if (healthPoints <= 1)
        {
            anim2.SetTrigger("popped");


        }
        if (healthPoints <= 0)
        {
            anim1.SetTrigger("popped");

        }
    }
}
