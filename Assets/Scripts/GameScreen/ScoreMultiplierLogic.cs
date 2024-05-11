using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplierLogic : MonoBehaviour
{
    private int currentMultiplier = 1;

    private ScoreMultiplierDisplay scoreMultiplierDisplay;
    public int CurrentMultiplier { get { return currentMultiplier; } }
    public void Start()
    {
        scoreMultiplierDisplay = FindObjectOfType<ScoreMultiplierDisplay>();
    }
    public void AddMultiplier()
    {
        if (currentMultiplier < 10)
        {
            currentMultiplier += 1;
        }
        scoreMultiplierDisplay.DisplayMultiplier(currentMultiplier);
        StopAllCoroutines();
        StartCoroutine(DeactivateMultiplier(10));
    }

    IEnumerator DeactivateMultiplier(int time)
    {
        yield return new WaitForSeconds(time);
        currentMultiplier = 1;
        scoreMultiplierDisplay.HideMultiplier();
    }
}
