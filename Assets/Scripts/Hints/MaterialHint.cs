    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHint : MonoBehaviour
{
    
    public Material greenMaterial;
    public Material redMaterial;
    Material originalMaterial;
    GameObject lastHighlightedObject;

    [SerializeField] private LayerMask PickupMask;

    [SerializeField] private float PickupRange = 5;

    [SerializeField] private Camera PlayerCam;
 
    void HighlightObject(GameObject hilightObject)
    {
        while (hilightObject.transform.parent)
        {
            hilightObject = hilightObject.transform.parent.gameObject;
        }
        if (lastHighlightedObject != hilightObject)
        {
            ClearHighlighted();
            GameObject hintObject = hilightObject.transform.Find("Hint").gameObject;
            hintObject.GetComponent<MeshRenderer>().enabled=true;
            lastHighlightedObject = hilightObject;

        }
 
    }
 
    void ClearHighlighted()
    {
        if (lastHighlightedObject != null)
        {
            GameObject hintObject = lastHighlightedObject.transform.Find("Hint").gameObject;
            hintObject.GetComponent<MeshRenderer>().enabled=false;
            lastHighlightedObject = null;
        }
    }
 
    void Update()
    {
        Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); 
        if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
        {
            HighlightObject(HitInfo.collider.gameObject);
        }
        else
        {
            ClearHighlighted();
        } 
    }

}
