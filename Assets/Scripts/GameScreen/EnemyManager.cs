using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public bool IsOnOuter;

    private bool triggered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            if (IsOnOuter == other.gameObject.GetComponentInParent<KolobokMovement>().IsOnOuterCircle && !other.gameObject.GetComponentInParent<KolobokMovement>().Invincible)
            { 
                FindObjectOfType<GameState>().IsOver = true;
                return;
            }
            gameObject.GetComponent<Animator>().SetBool("Off",true);
        }
    }
}
