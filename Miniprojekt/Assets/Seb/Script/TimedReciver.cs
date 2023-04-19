using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedReciver : MonoBehaviour,IInteractable
{
    [SerializeField] private Material black;
    [SerializeField] private Material red;
    [SerializeField] private Material yellow;
    [SerializeField] private Material green;
    [SerializeField] private MeshRenderer redMesh;
    [SerializeField] private MeshRenderer yellowMesh;
    [SerializeField] private MeshRenderer greenMesh;
    [SerializeField] private float maxTime;
    [SerializeField] private List<GameObject> blackList;
    [SerializeField] private List<GameObject> redList;
    [SerializeField] private List<GameObject> yellowList;
    [SerializeField] private List<GameObject> greenList;
    private float time;
    private bool hit;
    public void Interact()
    {
        if((time+Time.deltaTime)*2<maxTime)
        {
            time+=Time.deltaTime*2;
        }
        else
        {
            time=maxTime;
        }
        
    }
    private void Update()
    {       //switch needs const...
            //red
            if (time>0 && time<(maxTime/3))
                {
                 yellowMesh.material=black;
                 redMesh.material=red;
                 foreach(GameObject go in redList)
                    {
                        go.GetComponent<IInteractable>().Interact();
                    }
                }
            //yellow
            if (time >(maxTime/3) && time<(maxTime*2/3))
                {
                greenMesh.material=black;
                yellowMesh.material=yellow;
                foreach(GameObject go in yellowList)
                    {
                        go.GetComponent<IInteractable>().Interact();
                    }
                }
            //green
            if (time>=(maxTime*2/3))
                {
                foreach(GameObject go in greenList)
                    {
                        go.GetComponent<IInteractable>().Interact();
                    }
                greenMesh.material=green;
                }
            //black
            if (time==0)
                {
                foreach(GameObject go in blackList)
                    {
                        go.GetComponent<IInteractable>().Interact();
                    }
                redMesh.material=black;
                }
            if (time<Time.deltaTime)
            {time=0;
                return;
            }
            time-=Time.deltaTime;
    }
}
