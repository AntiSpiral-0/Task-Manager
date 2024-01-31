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
        public static void LogIn(string userName, string password)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new MySqlCommand("LogInUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userName", userName);
                command.Parameters.AddWithValue("@userPassword", password);
                command.ExecuteNonQuery();
            }
    }
}

public static void LogOut(string userName)
{
    using (var connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        using (var command = new MySqlCommand("LogOutUser", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@userName", userName);
            command.ExecuteNonQuery();
        }
    }
}
}