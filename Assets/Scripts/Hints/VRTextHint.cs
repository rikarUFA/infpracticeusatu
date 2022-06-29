#if UNITY_EDITOR_WIN
/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class VRTextHint : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    GameObject lastHighlightedObject;


    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    void HighlightObject(GameObject hilightObject)
    {
        //hilightObject = hilightObject.transform.parent.gameObject;
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

    public void PointerClick(object sender, PointerEventArgs e)
    {
        try
        {
            e.target.gameObject.GetComponent<DiscreteInteractor>().Next();
            e.target.gameObject.GetComponent<DiscreteInteractor>().Rotate();
        }
        catch
        {

        }

    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name != null)
        {
            Debug.Log(e.target.gameObject);
            HighlightObject(e.target.gameObject);
        }
        else
        {
            ClearHighlighted();
        }


/*        if (e.target.name == "Debloketor")
        {
            Debug.Log("Cube was entered");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was entered");
        }*/
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {/*
        if (e.target.name == "Debloketor")
        {
            Debug.Log("Cube was exited");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was exited");
        }*/
        ClearHighlighted();
    }
}
#endif