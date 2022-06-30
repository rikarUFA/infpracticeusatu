using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Data;
using System.ComponentModel.Design;
 
public class DB : MonoBehaviour
{
 
    private static DB _dbInstance = null;
    public static DB _DBInstance()
    {
        return _dbInstance;
    }
 
    private string dbName = "DB"; // имя базы данных
 
         // Устанавливаем соединение с базой данных
    SqliteConnection connection;
         // Команда базы данных
    SqliteCommand command;
         // Читатель базы данных
    SqliteDataReader reader;
 
    private void Awake()
    {
                 // Подключаемся к базе данных
        OpenConnect();
    }
 
    private void OnDestroy()
    {
                 // Отключаем соединение с базой данных
        CloseDB();
    }
 
    void Start()
    {
                 //// Создать таблицу
        //string[] colNames = new string[] { "name", "password" };
        //string[] colTypes = new string[] { "string", "string" };
        //CreateTable("user", colNames, colTypes);
 
                 //// Используйте обобщения для создания таблиц данных
        //CreateTable<T4>();
 
                 //// Находим определенные поля на основе условий
        //foreach (var item in SelectData("user", new string[] { "name" }, new string[] { "password", "123456" }))
        //{
        //    Debug.Log(item);
        //}
 
                 //// обновить данные
        //UpdataData("user", new string[] {"name", "yyy"}, new string[] { "name" ,"wxy" });
 
                 //// удалить данные
        //DeleteValues("user", new string[] { "name","wxyqq" });
 
 
                 //// Данные запроса
        //foreach (var item in GetDataBySqlQuery("T4", new string[] { "name" }))
        //{
        //    Debug.Log(item);
        //}
        foreach (var item in GetDataBySqlQuery("'Требуемые действия'",new string[] { "'id Родитеоя', 'id Потомка', 'Действие'"}))
        {
            Debug.Log(item);
        }
                 //// Вставить данные
        //string[] values = new string[] { "3", "33", "333" };
        //InsertValues("T4", values);
 
                 //// Используйте дженерики для вставки объектов
        //T4 t = new T4(2, "22", "222");
        //Insert<T4>(t);
    }
    
    void Update()
    {
       foreach (var item in GetDataBySqlQuery("'Фактические действия'",new string[] { "'id Родителя'"}))
        {
            Debug.Log(item);
        }
    }
    /// <summary>
         /// данные запроса
    /// </summary>
         /// <param name = "tableName"> имя таблицы </param>
         /// <param name = "fields"> нужно найти данные </param>
    /// <returns></returns>
    public List<String> GetDataBySqlQuery(string tableName, string[] fields)
    {
        string queryString = "select " + fields[0];
        for (int i = 1; i < fields.Length; i++)
        {
           queryString += " , " + fields[i];
        }
        queryString += " from " + tableName;
        List<string> list = new List<string>();
        return reader = ExecuteQuery(queryString);
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                object obj = reader.GetValue(i);
                list.Add(obj.ToString());
            }
        }
        return list;
    }
    
    /// <summary>
         /// Выполнить команду SQL
    /// </summary>
         /// <param name = "queryString"> строка команды SQL </param>
    /// <returns></returns>
    public SqliteDataReader ExecuteQuery(string queryString)
    {
        command = connection.CreateCommand();
        command.CommandText = queryString;
        reader = command.ExecuteReader();
        return reader;
    }
 
    /// <summary>
         /// Вставляем данные в указанную таблицу данных
    /// </summary>
    /// <param name="tableName"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public SqliteDataReader InsertValues(string tableName, string[] values)
    {
        string sql = "INSERT INTO " + tableName + " values (";
        foreach (var item in values)
        {
            sql += "'" + item + "',";
        }
        sql = sql.TrimEnd(',') + ")";
 
        Debug.Log ("Вставить успешно");
        return ExecuteQuery(sql);
    }

    /// <summary>
         /// Вставить данные
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public SqliteDataReader Insert<T>(T t)
    {
        var type = typeof(T);
        var fields = type.GetFields();
        string sql = "INSERT INTO " + type.Name + " values (";
 
        foreach (var field in fields)
        {
                         // Получаем значение объекта через отражение
            sql += "'" + type.GetField(field.Name).GetValue(t) + "',";
        }
        sql = sql.TrimEnd(',') + ");";
 
        Debug.Log ("Вставить успешно");
        return ExecuteQuery(sql);
    }
  
 
    /// <summary>
         /// обновить данные
    /// </summary>
    /// <param name="tableName"></param>
         /// <param name = "values"> данные, которые нужно изменить </param>
         /// <param name = "conditions"> измененные условия </param>
    /// <returns></returns>
    public SqliteDataReader UpdateData(string tableName, string[] values, string[] conditions)
    {
        string sql = "update " + tableName + " set ";
        for (int i = 0; i < values.Length - 1; i += 2)
        {
            sql += values[i] + "='" + values[i + 1] + "',";
        }
        sql = sql.TrimEnd(',') + " where (";
        for (int i = 0; i < conditions.Length - 1; i += 2)
        {
            sql += conditions[i] + "='" + conditions[i + 1] + "' and ";
        }
        sql = sql.Substring(0, sql.Length - 4) + ");";
        Debug.Log ("Обновлено успешно");
        return ExecuteQuery(sql);
    }
    public void Compare()
    {
        for (int i = 0; i < idRequiredAction.Length - 1; i ++)
        {
            for (int j = 0; j < rParent.Length - 1; j ++)
            {
                for (int k = 0; k < rChild.Length - 1; k ++)
                {
                    for (int l = 0; l < rAction.Length - 1; l ++)
                    {
                        for (int m = 0; m < aParent.Length - 1; m ++)
                        {
                            for (int n = 0; n < aChild.Length - 1; n ++)
                            {
                                for (int p = 0; p < aAction.Length - 1; p ++)
                                {
                                    if (rParent[j] != aParent[m])
                                    {
                                        UpdataData("'Отклонение'", new string[] {"'Признак отклонения'", "1"}, new string[] { "id Требуемого действия" , idRequiredAction[i]});
                                    }
                                    else if (rChild[k] != aChild[n])
                                    {
                                        UpdataData("'Отклонение'", new string[] {"'Признак отклонения'", "2"}, new string[] { "id Требуемого действия" , idRequiredAction[i]});
                                    }
                                    else if (rAction[l] != aAction[p])
                                    {
                                        UpdataData("'Отклонение'", new string[] {"'Признак отклонения'", "3"}, new string[] { "id Требуемого действия" , idRequiredAction[i]});
                                    }
                                    else 
                                    {
                                        UpdataData("'Отклонение'", new string[] {"'Признак отклонения'", "0"}, new string[] { "id Требуемого действия" , idRequiredAction[i]});
                                    }
                                }
                            }
                            
                        }
                        
                    }

                    
                }
                
            }
        }
        

    }
 
         // Открываем базу данных
    public void OpenConnect()
    {
        try
        {                  
            string path = Application.streamingAssetsPath + "/" + dbName + ".db";   
                         // Новое соединение с базой данных
            connection = new SqliteConnection(@"Data Source = " + path);
                         // Открываем базу данных 
            connection.Open();
            Debug.Log ("Открыть базу данных");
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }
 
         // Закрываем базу данных
    public void CloseDB()
    {
        if (command != null)
        {
            command.Cancel();
        }
        command = null;
 
        if (reader != null)
        {
            reader.Close();
        }
        reader = null;
 
        if (connection != null)
        {
            //connection.Close();
        }
        connection = null;
 
        Debug.Log ("Закройте базу данных");
    }
}

