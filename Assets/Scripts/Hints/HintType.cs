using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintType : MonoBehaviour
{
    [SerializeField]
    private bool m_AllowHint;

    public bool AllowHint
    {
        get
        {
            return m_AllowHint;
        }
        set
        {
            m_AllowHint = value;
        }
    }

}
