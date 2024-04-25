using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    private static int _score = 0;
    public GameObject GameOverPrefab;
    public static int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    private bool _isPlaying;
    public bool IsPlaying
    {
        get { return _isPlaying; }
        set
        {
            _isPlaying = value;
        }
    }
    private bool _IsOver;
    public bool IsOver
    {
        get { return _IsOver; }
        set
        {
            if (value == true)
            {
                IsPlaying = false;
                Instantiate(GameOverPrefab);
            }
            _IsOver = value;
        }
    }
    void Start()
    {
        IsPlaying = true;
        Score = 0;
    }


    // Update is called once per frame
    void Update()
    {
        Score = (int)((Time.timeSinceLevelLoad * 50) * FindObjectOfType<KolobokMovement>().speed);
        GameObject scoreObject = GameObject.Find("Score");

        TextMeshProUGUI scoreText = scoreObject.GetComponent<TextMeshProUGUI>();

        // Check if the Text component was found
        if (scoreText != null && IsPlaying)
        {
            // Access or modify the text value as needed
            scoreText.text = $"Score:{Score}";
        }
        if (Score % 1000 == 0 && Score != 0 && FindObjectOfType<KolobokMovement>().speed < 3)
        {
            FindObjectOfType<KolobokMovement>().speed += 0.1f;
        }
        if (!IsPlaying)
        {

        }
    }
}
