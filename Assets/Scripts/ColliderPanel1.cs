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
    private string dbname = "URI=file:database.db";
    // Start is called before the first frame update
    void Start()
    {
        CreateUsers();
        AddUsers();
        AddObjects();
    }

    public void CreateUsers()
    {

        using (var connection = new SqliteConnection(dbname))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                //Creating table "Users"
                command.CommandText = "CREATE TABLE IF NOT EXISTS Users (idUser INTEGER PRIMARY KEY NOT NULL, Username VARCHAR(20))";
                command.ExecuteNonQuery();
               
                //Creating table "Objects"
                command.CommandText = "CREATE TABLE IF NOT EXISTS Objects (idObject INTEGER PRIMARY KEY NOT NULL, Objectname VARCHAR(20))"; 
                command.ExecuteNonQuery();

                //Creating table "Events"
                command.CommandText = "CREATE TABLE IF NOT EXISTS Events (idEvents INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Event VARCHAR(20), DTEvent DATETIME, idUser INTEGER, idObject INTEGER, FOREIGN KEY (idUser) REFERENCES Users (idUser), FOREIGN KEY (idObject) REFERENCES Objects (idObject))";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }

    }

    int idUser = 1;
    string Username = "user1";

    int idObject = 1001;
    string Objectname = "Panel1";
     
    

    public void AddUsers()
    {
        using (var connection = new SqliteConnection(dbname))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Users (idUser, Username) VALUES ('" + idUser + "', '" + Username + "');";
                command.ExecuteNonQuery();

            }

            connection.Close();
        }
    }

    public void AddEvents(string Event, DateTime DTEvent)
    {
        using (var connection = new SqliteConnection(dbname))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {

                command.CommandText = "INSERT INTO Events (Event, DTEvent, idUser, idObject) VALUES ('" + Event + "', '" + DateTime.Now + "', '" + idUser + "', '" + idObject + "');";
                command.ExecuteNonQuery();

            }

            connection.Close();
        }
    }

    public void AddObjects()
    {
        using (var connection = new SqliteConnection(dbname))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
              
                command.CommandText = "INSERT INTO Objects (idObject, Objectname) VALUES ( '" + idObject + "', '" + Objectname + "');";
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

            AddEvents("enter", DateTime.Now);

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
            AddEvents("exit", DateTime.Now);

        }
    }
}
