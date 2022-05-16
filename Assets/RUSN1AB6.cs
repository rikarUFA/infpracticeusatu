using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUSN1AB6 : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update

    private float x;
    private bool rotateX;

    void Start()
    {
        x = -52.0f;
        rotateX = true;
    }

    // Update is called once per frame
    void Update()
    {

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
