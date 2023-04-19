using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatToggleBorder : MonoBehaviour,IToggle
{
    public bool startOn;
    [SerializeField] private GameObject border;
    void Start()
    {
        if(startOn)
        {
            on();
        }
        else
        {
            off();
        }
    }
    public void on(){border.SetActive(true);}
    public void off(){border.SetActive(false);}
}
