using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DisplayScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreObject = GameObject.Find("CurrentScore");

        TextMeshProUGUI scoreText = scoreObject.GetComponent<TextMeshProUGUI>();

        GameObject highScoreObject = GameObject.Find("HighScore");

        TextMeshProUGUI highScoreText = highScoreObject.GetComponent<TextMeshProUGUI>();


        // Check if the Text component was found
        if (scoreText != null)
        {
            // Access or modify the text value as needed
            scoreText.text = $"Current score:{GameState.Score}";
        }

        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (GameState.Score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", GameState.Score);
                highScoreText.text = $"High score:{GameState.Score} (new)";
            }
            else {
                highScoreText.text = $"High score:{PlayerPrefs.GetInt("HighScore")}";
            }

        }
        else {
            PlayerPrefs.SetInt("HighScore", GameState.Score);
            highScoreText.text = $"High score:{GameState.Score} (new)";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
