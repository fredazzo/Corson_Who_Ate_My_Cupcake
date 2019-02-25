using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play_Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("T"))
            SceneManager.LoadScene("Tutorial");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Shot")
        {
            SceneManager.LoadScene("Main_Scene");
        }
    }
}
