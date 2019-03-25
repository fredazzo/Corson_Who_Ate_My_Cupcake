using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_menu_controller : MonoBehaviour
{
    public GameObject musicPlayer;
    new AudioSource audio;
    void Awake()
    {
        musicPlayer = GameObject.Find("MUSIC");

        if (musicPlayer == null)
        {
            musicPlayer = this.gameObject;
            musicPlayer.name = "MUSIC";
            audio = GetComponent<AudioSource>();
            audio.Play();

            DontDestroyOnLoad(musicPlayer);
        }
        else
        {
            if (this.gameObject.name != "MUSIC")
                Destroy(this.gameObject);
        }
    }
}
