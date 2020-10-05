// <copyright file="SqlDatabaseHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// Provides helper functions for all SQL database related operations.
    /// </summary>
    public class SqlDatabaseHelper : ISqlDatabaseHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDatabaseHelper"/> class.
        /// </summary>
        /// <param name="connectionString">The SQL database connection string.</param>
        public SqlDatabaseHelper(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private string ConnectionString { get; set; }

        /// <summary>
        /// Executes an SQL write command.
        /// </summary>
        /// <param name="command">The SQL command.</param>
        /// <returns>The number of rows affected by the command.</returns>
        public int ExecuteWriteCommand(string command)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(command);
                return affectedRows;
            }
        }

        /// <summary>
        /// Executes an SQL read command.
        /// </summary>
        /// <param name="query">The SQL command.</param>
        /// <param name="numberOfRecordsToReturn">The number of records to return.</param>
        /// <returns>The query result.</returns>
        public List<object[]> ExecuteReadCommand(string query, int numberOfRecordsToReturn)
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
