using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject LoosePopup;
    public GameObject WinPopup;
    void Start()
    {
        var currentScore = GameState.Score;

        GameObject scene;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (currentScore > PlayerPrefs.GetInt("HighScore"))
            {
                scene = Instantiate(WinPopup);
            }
            else {
                scene = Instantiate(LoosePopup);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", GameState.Score);
            scene = Instantiate(WinPopup);
        }

        scene.transform.Find("Node/Rushnyk/Setting_Rushnyk/Canvas/Score").GetComponent<TextMeshProUGUI>().text = currentScore.ToString();
        scene.transform.Find("Node/Rushnyk/Setting_Rushnyk/Canvas/Record").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore").ToString();

    }
}
