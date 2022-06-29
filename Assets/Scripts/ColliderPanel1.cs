#if UNITY_EDITOR_WIN
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using System.Data;
using System.ComponentModel.Design;
using System;

public class ColliderPanel1 : MonoBehaviour
{
    DB dB;
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("enter");
            dB.ActualActions(1, 1, 2, 3, "O", DateTime.Now, "Выбрать Панель 1");


        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("exit");
            

        }
    }
}
#endif