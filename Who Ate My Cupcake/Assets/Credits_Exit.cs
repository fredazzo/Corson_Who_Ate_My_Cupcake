using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits_Exit : MonoBehaviour
{
    public float credits_exit_time;
    void Update()
    {
        StartCoroutine(Credits_exit());
    }

    IEnumerator Credits_exit()
    {
        yield return new WaitForSeconds(credits_exit_time);
        SceneManager.LoadScene("Main_Menu");
    }
}
