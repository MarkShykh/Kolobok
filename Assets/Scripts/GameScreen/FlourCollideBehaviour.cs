using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourCollideBehaviour : MonoBehaviour
{
    private bool triggered = false;
    [SerializeField] private AudioClip consume;
    [SerializeField] private AudioClip power;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;

            if (gameObject.GetComponentInParent<IsOnOuter>().isOnOuter == other.gameObject.GetComponentInParent<KolobokMovement>().IsOnOuterCircle)
            {
                gameObject.GetComponentInParent<Animator>().SetBool("Consume", true);
                other.gameObject.GetComponentInParent<Animator>().SetBool("Consume",true);
                other.gameObject.GetComponentInParent<Animator>().SetBool("SuperPower", true);
                other.gameObject.GetComponentInParent<KolobokMovement>().SuperPowerStart();
                SFXBehaviour.instance.PlaySoundFXClip(consume, 1f);
                SFXBehaviour.instance.PlaySoundFXClip(power, 1f);
                return;
            }
            gameObject.GetComponentInParent<Animator>().SetBool("Off", true);

        }
    }
}
