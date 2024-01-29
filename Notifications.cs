using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata.Ecma335;
using Management;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
static class TaskmanagerDB
    {
        static string connectionString = "server=localhost;database=task manager;uid=root;pwd=;";
        static IDbConnection connection = new MySqlConnection(connectionString);
        public static List<dynamic> AddEmployee(string Name,string Position,string Password , string Email)
        {
            string sql = "INSERT INTO employees (employeeID , name , position , email , password ) VALUES (NULL, @name , @position , @email ,@password )";
            connection.Execute(sql, new { employeeID = "NULL" , name = Name , position = Position , email = Email , password = Password});
            string query = "SELECT * FROM employees WHERE SomeCondition = @SomeValue";
            var result = connection.Query<dynamic>(query, new { SomeValue = "SomeCriteria" });
            Console.WriteLine("Current List of Users");
            return result.AsList();
        }
    }
class Tasks
{
    private string task ;
    private int id;
    public string Task
    {
        get{return task;}
        set{task = value;}
    }
    public int Id
    {
        get{return id;}
        set{id = value;}
    }
    public Tasks (string task , int id)
    {
       Task = task;
       Id = id;
    }
}
class Notifications
{

}
