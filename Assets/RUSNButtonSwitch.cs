using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUSNButtonSwitch : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    IInteractable interactable;
    private float x;
    private float z;
    private bool rotateX;
    // private float rotationSpeed;

    void Start()
    {
        x = -52.0f;

        rotateX = true;
        // rotationSpeed = 38.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Interact();
    }

    public void Interact()
    {
        if (rotateX == true)
        {
            x += 90;
            Debug.Log("RUSN interact on");
            if (x > 38.0f)
            {
                x = -52.0f;
                Debug.Log("RUSN interact off");
            }
        }


        transform.localRotation = Quaternion.Euler(x, 0, 0);
    }

}
