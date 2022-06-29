using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class CapSW : MonoBehaviour, IInteractable
{
    IInteractable interactable;
    public Transform cap;
    public bool fopen = true;
    // Start is called before the first frame update
    void Start()
    {
        fopen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fopen)
        {
            Debug.Log("Cap interact1");
            Interact();

            fopen = true;
        }

    }
    public void Interact()
    {
        //frot = true;
        cap.Rotate(90, 0, 0, Space.World);
        Debug.Log("Cap interact");
        fopen = !fopen;
        //(0, 15, 0, Space.World);

        //else transform.Rotate(0, 0, 0, Space.World);
    }
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Hand>()) Interact();
    }
}
