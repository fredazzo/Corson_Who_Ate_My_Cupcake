using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooty_Arm : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            anim.SetTrigger("hasShot");
    }
}
