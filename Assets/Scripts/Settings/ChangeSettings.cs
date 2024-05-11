using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSettings : MonoBehaviour
{
    public SpriteRenderer[] MusicSprites;
    public SpriteRenderer[] SoundSprites;
    private void Start()
    {
        // Display the settings when the scene starts
        if (!(PlayerPrefs.HasKey("Sound") && PlayerPrefs.HasKey("Music")))
        {
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.SetInt("Music", 1);
        }
        DisplaySettings();

    }

    private void DisplaySettings()
    {
        foreach (var sprite in MusicSprites)
        { sprite.color = Color.clear; }
        foreach (var sprite in SoundSprites)
        { sprite.color = Color.clear; }
        // Check PlayerPrefs for sound and music settings and update the toggles accordingly
        if (PlayerPrefs.HasKey("Sound"))
        {
            SoundSprites[PlayerPrefs.GetInt("Sound")].color = Color.white;
        }

        if (PlayerPrefs.HasKey("Music"))
        {
            MusicSprites[PlayerPrefs.GetInt("Music")].color = Color.white;
        }
    }

    public void ToggleSound()
    {
        // Save the sound setting to PlayerPrefs when the toggle state changes
        PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound") == 1 ? 0 : 1);
        DisplaySettings();
    }

    public void ToggleMusic()
    {
        // Save the music setting to PlayerPrefs when the toggle state changes
        PlayerPrefs.SetInt("Music", PlayerPrefs.GetInt("Music") == 1 ? 0 : 1);
        DisplaySettings();
    }
}
