#if UNITY_EDITOR_WIN
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHint : MonoBehaviour
{
    Material originalMaterial;
    GameObject lastHighlightedObject;

    [SerializeField] private LayerMask PickupMask;

    [SerializeField] private float PickupRange = 5;

    // [SerializeField] private Camera PlayerCam;
 
    void HighlightObject(GameObject hilightObject)
    {
        if (lastHighlightedObject != hilightObject)
        {
            ClearHighlighted();
            GameObject hintObject = hilightObject.transform.Find("Hint").gameObject;
            hintObject.GetComponent<MeshRenderer>().enabled = true;
            lastHighlightedObject = hilightObject;
        }
 
    }
 
    void ClearHighlighted()
    {
        if (lastHighlightedObject != null)
        {
            GameObject hintObject = lastHighlightedObject.transform.Find("Hint").gameObject;
            hintObject.GetComponent<MeshRenderer>().enabled = false;
            lastHighlightedObject = null;
        }
    }
 
    void Update()
    {
        Ray CameraRay = gameObject.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); 
        if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
        {
            try
            {
                HighlightObject(HitInfo.collider.gameObject);
            }
            catch
            {

            }
        }
        else
        {
            ClearHighlighted();
        } 
    }

}
#endif