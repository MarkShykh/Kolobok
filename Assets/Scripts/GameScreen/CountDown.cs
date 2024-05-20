using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    private AudioClip countdown;
    private int countdownTime = 3;
    void Start()
    {
        StartCoroutine(Countdown());

    }

    IEnumerator Countdown()
    {
        SFXBehaviour.instance.PlaySoundFXClip(countdown, 1f);
        FindObjectOfType<SoundMixerManager>().SetMusicVolume(-40);
        var countdownText = GetComponent<TextMeshProUGUI>();

        while (countdownTime >= 0)
        {
            countdownText.text = countdownTime == 0 ? countdownText.text = "GO!": countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        FindObjectOfType<SoundMixerManager>().SetMusicVolume(-20);
        GetComponent<Animator>().SetTrigger("Go");
        FindObjectOfType<GameState>().IsPlaying = true;
    }
}
