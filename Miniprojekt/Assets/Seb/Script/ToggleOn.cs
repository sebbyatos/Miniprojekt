using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOn : MonoBehaviour,IInteractable
{
     public GameObject toggle;
     public void Interact()
    {toggle.GetComponent<IToggle>().on();}
}
