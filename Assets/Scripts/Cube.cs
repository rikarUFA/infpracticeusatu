using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using System.Data;
using System.ComponentModel.Design;


public class Cube : MonoBehaviour
{
    private bool enter=false;
    private string dbname = "URI=file:DB.db";
    // Start is called before the first frame update
    void Start()
    {
        CreateDB();

        
       

        
    }

    public void CreateDB()
    {
        
        using (var connection = new SqliteConnection(dbname))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS events (objectname VARCHAR(20), DTEvent VARCHAR(20))"; 
                command.ExecuteNonQuery();
            }
            
            connection.Close();
        }
    }
    
    public void AddEvents(string objectname, string DTEvent)
    {
        using (var connection = new SqliteConnection(dbname))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO events (objectname, DTEvent) VALUES ('" + objectname + "', '" + DTEvent + "');";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            // Insert values in table
            enter = true;
            Debug.Log("enter");
            AddEvents("Cube", "enter");
           
            // куб idobject 1 
            // шар idobject 2 
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            enter = false;
            Debug.Log("exit");
            AddEvents("Cube", "exit");

        }
    }
}
