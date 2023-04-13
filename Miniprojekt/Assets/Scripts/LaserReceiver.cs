using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiver : MonoBehaviour
{
    [SerializeField] private Material unlit;
    [SerializeField] private Material lit;
    [SerializeField] private MeshRenderer toBeLit;

    [SerializeField] private ParticleSystem particleSystem;

    [SerializeField] private GameObject interactable;

    public bool isLit;

    public void LightReceiver()
    {
        isLit = true;
        toBeLit.material = lit;
        
        particleSystem.Play();
        
        Debug.Log("Triggering");
        interactable.GetComponent<IInteractable>().Interact();
    }
}
