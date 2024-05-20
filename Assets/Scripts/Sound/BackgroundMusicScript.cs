using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<AudioSource>().mute = PlayerPrefs.GetInt("Music") == 0;
    }

}
