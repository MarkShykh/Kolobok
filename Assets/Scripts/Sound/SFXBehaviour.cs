using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SFXBehaviour : MonoBehaviour
{
    public static SFXBehaviour instance;

    [SerializeField] private AudioSource soundFXObject;

    [SerializeField] private AudioClip buttonClip;
    private void Awake()
    {
        if(instance == null)
            instance = this;
        Button[] buttons = FindObjectsOfType<Button>(true); // parameter makes it include inactive UI elements with buttons
        foreach (Button b in buttons)
        {
            b.onClick.AddListener(ButtonSound);
        }
    }
    public void ButtonSound()
    {
        PlaySoundFXClip(buttonClip, 1f);
    }

    public void PlaySoundFXClip(AudioClip clip, float volume)
    {
        AudioSource audioSorce = Instantiate(soundFXObject);

        audioSorce.clip = clip;

        audioSorce.volume = volume;

        audioSorce.Play();

        float clipLenght = audioSorce.clip.length;

        Destroy(audioSorce.gameObject, clipLenght);
    }
}
