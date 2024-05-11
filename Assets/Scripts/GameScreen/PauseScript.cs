using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseScreen;
    public void OnPause()
    {
        PauseScreen.gameObject.GetComponent<Animator>().SetBool("Off", false);
        PauseScreen.gameObject.GetComponent<Animator>().SetBool("On", true);
        FindObjectOfType<GameState>().IsPlaying = false;
    }

    public void OnPlay()
    {
        PauseScreen.gameObject.GetComponent<Animator>().SetBool("On", false);
        PauseScreen.gameObject.GetComponent<Animator>().SetBool("Off", true);
        FindObjectOfType<GameState>().IsPlaying = true;
    }
}
