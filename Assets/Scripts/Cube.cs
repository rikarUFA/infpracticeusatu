#if UNITY_EDITOR_WIN
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using System.Data;
using System.ComponentModel.Design;


public class Cube : MonoBehaviour
{
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

   

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("enter");
            AddEvents("Cube", "enter");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("exit");
            AddEvents("Cube", "exit");

        }
    }
}
#endif