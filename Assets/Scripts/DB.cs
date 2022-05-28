using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using System.Data;
using System.ComponentModel.Design;
using System;


public class DB : MonoBehaviour
{
    public string dbname = "URI=file:DB.db";
    
    // Start is called before the first frame update
    void Start()
    {
        //Training(1, 1, DateTime.Now, "������");
       // Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    public void Training(int id_user, int id_scenario, DateTime dateTime, string resultOfTraining)
    {
        using (var connection = new SqliteConnection(dbname))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {

                command.CommandText = "INSERT INTO '��������' ('id ������������', 'id ��������', '���� � �����', '��������� ��������') VALUES ('" + id_user + "', '" + id_scenario + "', '" + dateTime + "', '" + resultOfTraining + "');";
                command.ExecuteNonQuery();

            }

            connection.Close();
        }
    }
    public void ActualActions(int id_sessions, int id_scenario, int? id_parent, int? id_child, string action, DateTime datetime, string nameOperation)
    {
        using (var connection = new SqliteConnection(dbname))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {

                command.CommandText = "INSERT INTO '����������� ��������' ('id ������', 'id ��������', 'id ��������', 'id �������', '��������', '���� � ����� ��������', '�������� ��������') VALUES ('" + id_sessions + "', '" + id_scenario + "', '" + id_parent + "', '" + id_child + "', '" + action + "', '" + datetime + "', '" + nameOperation + "');";
                command.ExecuteNonQuery();

            }

            connection.Close();
        }
    }

}
