﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    IInteractable interactable;
    public bool frot = true;
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
        transform.Rotate(0, 0, 45, Space.World);
        Debug.Log("Switch interact");
        //frot = !frot;
        //(0, 15, 0, Space.World);

        //else transform.Rotate(0, 0, 0, Space.World);

        
    }
}