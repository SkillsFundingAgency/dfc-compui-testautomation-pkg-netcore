// <copyright file="SqlDatabaseConnectionHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DFC.TestAutomation.UI.Helper
{
    public class SqlDatabaseConnectionHelper : ISqlDatabaseConnectionHelper
    {
        public SqlDatabaseConnectionHelper(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private string ConnectionString { get; set; }

        public int ExecuteSqlCommand(string query)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(query);
                return affectedRows;
            }
        }

        public int ExecuteSqlCommand(string query, Dictionary<string, string> parameters)
        {
            using (var databaseConnection = new SqlConnection(this.ConnectionString))
            {
                databaseConnection.Open();
                using (var command = new SqlCommand(query, databaseConnection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    return command.ExecuteNonQuery();
                }
            }
        }

        public List<object[]> ReadDataFromDataBase(string query, int numberOfRecordsToReturn)
        {
            using (var databaseConnection = new SqlConnection(this.ConnectionString))
            {
                databaseConnection.Open();
                using (var command = new SqlCommand(query, databaseConnection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<object[]> result = new List<object[]>();
                    while (dataReader.Read())
                    {
                        object[] items = new object[numberOfRecordsToReturn];
                        dataReader.GetValues(items);
                        result.Add(items);
                    }

                    return result;
                }
            }
        }
    }
}
