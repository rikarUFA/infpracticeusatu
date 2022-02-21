using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch1 : MonoBehaviour, IInteractable
{
    IInteractable interactable;
    public bool frot = true;
    int k;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (frot)
        {
            Interact();
            frot = false;            
        }
        
    }
    public void Interact()
    {
        //frot = true;
        transform.Rotate(0, 90, 0, Space.Self);
        Debug.Log("Switch1 interact");
		
		
       
        //Debug.Log(k);
        //frot = !frot;
        //(0, 15, 0, Space.World);

        //else transform.Rotate(0, 0, 0, Space.World);


    }
}
