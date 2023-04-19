using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldDoor : MonoBehaviour, IToggle
{
    public bool ein;
    [SerializeField] private Collider door;
    [SerializeField] private MeshRenderer doormesh;
    // Start is called before the first frame update
    void Start()
    {
        door.enabled = ein;
        doormesh.enabled= ein;
    }

    public void on()
    {
        door.enabled = true;
        doormesh.enabled= true;
    }
    public void off()
    {
        door.enabled = false;
        doormesh.enabled= false;
    }
}
