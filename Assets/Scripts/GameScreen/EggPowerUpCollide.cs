using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggPowerUpCollide : MonoBehaviour
{
    private bool triggered = false;
    public GameObject multiplierPrefab;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered) 
        {
            triggered = true;
            
            if (gameObject.GetComponentInParent<IsOnOuter>().isOnOuter == other.gameObject.GetComponentInParent<KolobokMovement>().IsOnOuterCircle)
            {
                gameObject.GetComponentInParent<Animator>().SetBool("Consume", true);
                other.gameObject.GetComponentInParent<Animator>().SetBool("Consume", true);
                FindObjectOfType<ScoreMultiplierLogic>().AddMultiplier();
                FindObjectOfType<MultiplierPopup>().Display(gameObject.transform);
                return;
            }
            gameObject.GetComponentInParent<Animator>().SetBool("Off", true);

        }
    }

}
