using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] 
    private AudioMixer audioMixer;
    private const float maxVolume = 0f;

    public void Start()
    {
        audioMixer.SetFloat("SoundVolume", PlayerPrefs.GetInt("Sound") == 1 ? maxVolume : -80);
        audioMixer.SetFloat("MusicVoulme", PlayerPrefs.GetInt("Music") == 1 ? maxVolume : -80);
    }
    public void SetSoundFXEnabled(bool enabled)
    {
        audioMixer.SetFloat("SoundVolume",enabled ? maxVolume : -80);
    }

    public void SetMusicEnabled (bool enabled) {
        audioMixer.SetFloat("MusicVoulme", enabled ? maxVolume : -80);
    }

    public void SetMusicVolume (float volume)
    {
        if(PlayerPrefs.GetInt("MusicVoulme") == 1)
            audioMixer.SetFloat("MusicVoulme", volume);
    }

    
}
