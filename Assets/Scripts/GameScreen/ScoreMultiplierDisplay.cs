using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreMultiplierDisplay : MonoBehaviour
{
    public void DisplayMultiplier(int multiplier)
    { 
        gameObject.GetComponent<TextMeshProUGUI>().text = $"X{multiplier}";
    }

    public void HideMultiplier()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "";
    }
}
