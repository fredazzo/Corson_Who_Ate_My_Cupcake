using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending_scene_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
            SceneManager.LoadScene("Main_Menu");
        if (Input.GetButtonDown("R"))
            SceneManager.LoadScene("Main_Game");
    }
}
