using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Animator animator;

    private bool wasInteracted;

    public void Interact()
    {
        if(wasInteracted) return;

        Debug.Log("Interacting");
        animator.SetTrigger("DoorOpening");
        wasInteracted = true;
    }
}
