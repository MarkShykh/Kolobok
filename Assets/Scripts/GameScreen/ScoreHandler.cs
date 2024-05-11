using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private static int _score = 0;

    private KolobokMovement _kolobok;
    private ScoreMultiplierLogic _scoreMultiplierLogic;
    private TextMeshProUGUI _scoreText;
    public static int Score
    {
        get { return _score; }
    }
    void Start()
    {
        _kolobok = FindObjectOfType<KolobokMovement>();
        _scoreMultiplierLogic = FindObjectOfType<ScoreMultiplierLogic>();
        _scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        _score = 0;
    }

    void Update()
    {
        _score += ((int)((Time.timeSinceLevelLoad > 10 ? Time.timeSinceLevelLoad : 10) * _kolobok.speed) / 10) * _scoreMultiplierLogic.CurrentMultiplier;

        TextMeshProUGUI scoreText = _scoreText;

        if (scoreText != null && FindObjectOfType<GameState>().IsPlaying)
        {
            scoreText.text = $"{Score}";
        }
        if (Score % 1000 == 0 && Score != 0 && _kolobok.speed < 3)
        {
            _kolobok.speed += 0.1f;
        }
    }
}
