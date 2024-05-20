using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator SettingsAnimator;
    public void OnPlayButton()
    {
        SceneController.instance.LoadLevel(1);
    }

    public void OnSettingsButton() {
        SettingsAnimator.SetBool("On",true);
    }
}
