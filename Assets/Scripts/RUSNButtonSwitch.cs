using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RUSNButtonSwitch : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    IInteractable interactable;
    private float x;
    private float z;
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
    DB dB = new DB();
    
    public void Interact()
    {
        string objectName = gameObject.name;
        if (rotateX == true)
        {
            x += 90;
            Debug.Log("RUSN interact off");

            if (objectName == "RUSNButton4")
            {
                dB.ActualActions(1, 1, 3, 4, "CS", DateTime.Now, "Выбрать " + objectName);
                dB.ActualActions(1, 1, 4, null, "CI", DateTime.Now, "Отключить " + objectName);
            }
            else if (objectName == "RUSNButton5")
            {
                dB.ActualActions(1, 1, 3, 5, "CS", DateTime.Now, "Выбрать " + objectName);
                dB.ActualActions(1, 1, 5, null, "CI", DateTime.Now, "Отключить " + objectName);
            }
            else
            {
                dB.ActualActions(1, 1, 3, null, "CS", DateTime.Now, "Выбрать " + objectName);
                dB.ActualActions(1, 1, null, null, "CI", DateTime.Now, "Отключить " + objectName);
            }
                
           
            if (x > 38.0f)
            {
                x = -52.0f;
                Debug.Log("RUSN interact on");
                if (objectName == "RUSNButton4")
                {
                    dB.ActualActions(1, 1, 3, 4, "CS", DateTime.Now, "Выбрать " + objectName);
                    dB.ActualActions(1, 1, 4, null, "CI", DateTime.Now, "Включить " + objectName);
                }
                else if (objectName == "RUSNButton5")
                {
                    dB.ActualActions(1, 1, 3, 5, "CS", DateTime.Now, "Выбрать " + objectName);
                    dB.ActualActions(1, 1, 5, null, "CI", DateTime.Now, "Включить " + objectName);
                }
                else
                {
                    dB.ActualActions(1, 1, 3, null, "CS", DateTime.Now, "Выбрать " + objectName);
                    dB.ActualActions(1, 1, null, null, "CI", DateTime.Now, "Включить " + objectName);
                }

            }
        }


        transform.localRotation = Quaternion.Euler(x, 0, 0);
    }

}
