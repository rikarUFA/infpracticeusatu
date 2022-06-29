using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteInteractor : MonoBehaviour
{
    public int value = 0;
    public int min = 0;
    public int max = 9;
    public bool allowPrevious = true;
    public GameObject interactionObject;
    public bool rotateX = false;
    public bool rotateY = true;
    public bool rotateZ = false;
    public GameObject Hint = null;

    private void Start()
    {
        
    }

    public int Next()
    {
        if (value == max)
        {
            value = min;
        }
        else
        {
            value++;
        }
        return value;
    }

    public int Previous()
    {
        if (allowPrevious)
        {
            if (value == min)
            {
                value = 9;
            }
            else
            {
                value--;
            }
        }
        return value;
    }

    public void Rotate()
    {
        float x = interactionObject.transform.rotation.x;
        float y = interactionObject.transform.rotation.y;
        float z = interactionObject.transform.rotation.z;
        interactionObject.transform.Rotate(rotateX ? -360.0f / (max - min + 1) : 0, rotateY ? -360.0f / (max - min + 1) : 0, rotateZ ? -360.0f / (max - min + 1) : 0, Space.Self);
        if (Hint)
        {
            if (max == 1)
            {
                Hint.GetComponent<TMPro.TextMeshPro>().text = "Текущщее положение переключателя: " + ((value == 0)?"Выкл.":"Вкл.");
            }
            else
            {
                Hint.GetComponent<TMPro.TextMeshPro>().text = "Текущщее положение переключателя: " + (value + 1);
            }
        }
    }
}
