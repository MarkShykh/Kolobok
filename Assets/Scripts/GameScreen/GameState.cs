using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public  class GameState : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject GameOverPrefab;


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
    }
}
