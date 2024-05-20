using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseScreen;
    public void OnPause()
    {
        if (!FindObjectOfType<GameState>().IsOver && FindObjectOfType<GameState>().IsPlaying)
        {
            FindObjectOfType<SoundMixerManager>().SetMusicVolume(-40);
            PauseScreen.gameObject.GetComponent<Animator>().SetBool("Off", false);
            PauseScreen.gameObject.GetComponent<Animator>().SetBool("On", true);
            FindObjectOfType<GameState>().IsPlaying = false;
        }
    }

    public void OnPlay()
    {
        if (!FindObjectOfType<GameState>().IsPlaying && !FindObjectOfType<GameState>().IsOver)
        {
            FindObjectOfType<SoundMixerManager>().SetMusicVolume(-20);
            PauseScreen.gameObject.GetComponent<Animator>().SetBool("On", false);
            PauseScreen.gameObject.GetComponent<Animator>().SetBool("Off", true);
            FindObjectOfType<GameState>().IsPlaying = true;
        }
    }
}
