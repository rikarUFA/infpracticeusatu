using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewText : MonoBehaviour, IInteractable
{
   IInteractable interactable;
    public GameObject text;
    public bool check=false;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            Interact();
            check = false;
        }
    }
  
    public void Interact()
    {
  
        text.SetActive(!text.activeSelf);
        Debug.Log("Cylinder interact");

     }
}
