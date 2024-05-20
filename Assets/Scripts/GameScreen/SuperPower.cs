using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPower : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<KolobokMovement>().speed *= 5;
        animator.gameObject.GetComponent<KolobokMovement>().Invincible = true;
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<KolobokMovement>().speed /= 5;
        animator.gameObject.GetComponent<KolobokMovement>().Invincible = false;
        animator.SetBool("Consume",false);
        animator.SetBool("SuperPower",false);
    }
}
