using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public bool IsOnOuter;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (IsOnOuter == other.gameObject.GetComponentInParent<KolobokMovement>().IsOnOuterCircle)
            { 
                Destroy(other.gameObject);
                FindObjectOfType<GameState>().IsOver = true;
                
                return;
            }
            gameObject.transform.GetComponent<Animator>().SetBool("Off",true);
        }
    }
}
