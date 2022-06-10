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
    private bool enter = false;
   
      
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    DB dB = new DB();
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            // Insert values in table
            enter = true;
            Debug.Log("enter");
            dB.ActualActions(1, 1, 2, 3, "O", DateTime.Now, "Выбрать Панель 1");


            // ��� idobject 1 
            // ��� idobject 2 
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            enter = false;
            Debug.Log("exit");
            

        }
    }
}
