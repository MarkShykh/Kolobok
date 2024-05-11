using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButtons : MonoBehaviour
{
    [SerializeField]
    private Animator SettingsAnimator;
    public void OnSaveButon()
    {
        OnCloseButton();
    }

    public void OnCloseButton()
    {
        SettingsAnimator.SetBool("On", false);
    }
}
