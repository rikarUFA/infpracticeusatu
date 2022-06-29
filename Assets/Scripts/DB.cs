#if UNITY_EDITOR_WIN
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
        //Deviation();
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

                command.CommandText = "INSERT INTO 'Обучение' ('id Пользователя', 'id Сценария', 'Дата и время', 'Результат обучения') VALUES ('" + id_user + "', '" + id_scenario + "', '" + dateTime + "', '" + resultOfTraining + "');";
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

                command.CommandText = "INSERT INTO 'Фактические действия' ('id Сеанса', 'id Сценария', 'id Родителя', 'id Потомка', 'Действие', 'Дата и время действия', 'Название операции') VALUES ('" + id_sessions + "', '" + id_scenario + "', '" + id_parent + "', '" + id_child + "', '" + action + "', '" + datetime + "', '" + nameOperation + "');";
                command.ExecuteNonQuery();

            }

            connection.Close();
        }
    }

    public void Deviation()
    {
        using (var connection = new SqliteConnection(dbname))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT IGNORE INTO 'Отклонение' (SELECT 'id Требуемого действия' AS 'id Требуемого действия' FROM 'Требуемые действия');";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

}
#endif