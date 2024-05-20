using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TouchManagerScript : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction action;

    private KolobokMovement kolobok;

    public GameObject kolobokObject;

    [SerializeField]
    private AudioClip[] jumpClips;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        action = playerInput.actions.FindAction("TouchPress");
        kolobok = FindObjectOfType<KolobokMovement>();
    }

    private void OnEnable()
    {
        action.performed += TouchPressed;    
    }

    private void OnDisable()
    {
        action.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        SFXBehaviour.instance.PlaySoundFXClip(jumpClips[Random.Range(0,jumpClips.Length)],1f);
        kolobok.radius = kolobok.IsOnOuterCircle ? KolobokMovement.InnerRadius : KolobokMovement.Outerradius;
        kolobok.IsOnOuterCircle = !kolobok.IsOnOuterCircle;
        var animator = kolobokObject.GetComponent<Animator>();

        animator.SetTrigger("JumpIn");
    }
    
}
