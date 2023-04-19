using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOff : MonoBehaviour,IInteractable
{
   public GameObject toggle;
     public void Interact()
    {toggle.GetComponent<IToggle>().off();}
}
