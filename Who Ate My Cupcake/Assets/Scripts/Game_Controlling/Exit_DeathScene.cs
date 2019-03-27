using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit_DeathScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Submit"))
            SceneManager.LoadScene("Main_Menu");

        if (Input.GetButton("R"))
            SceneManager.LoadScene("Main_Game");

    }
}
