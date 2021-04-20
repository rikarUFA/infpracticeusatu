using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLocator : MonoBehaviour
{
    public Transform selection = null;
    public LayerMask layerMask;
    public float dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * dist, Color.green);
        if (Physics.Raycast(ray, out hit, dist, layerMask))
        {
           
            selection = hit.transform;
            if (selection != null)
            {
                //                Debug.Log(" *** ");
                Debug.Log(" Name =" + selection.gameObject.name);                
                IInteractable interactable = selection.GetComponent<IInteractable>();
                if  (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }


        }
    }
}
