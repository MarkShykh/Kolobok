using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAgain : MonoBehaviour
{
    public void OnStartAgainButton()
    {
        SceneController.instance.LoadLevel(1);
    }

    public void Home()
    {
        SceneController.instance.LoadLevel(0);
    }
}
