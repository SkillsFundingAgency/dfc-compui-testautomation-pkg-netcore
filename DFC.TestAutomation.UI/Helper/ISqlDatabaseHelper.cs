// <copyright file="ISqlDatabaseHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// Provides helper functions for all SQL database related operations.
    /// </summary>
    public interface ISqlDatabaseHelper
    {
        /// <summary>
        /// Executes an SQL write command.
        /// </summary>
        /// <param name="command">The SQL command.</param>
        /// <returns>The number of rows affected by the command.</returns>
        int ExecuteWriteCommand(string command);

        /// <summary>
        /// Executes an SQL read command.
        /// </summary>
        /// <param name="command">The SQL command.</param>
        /// <param name="numberOfRecordsToReturn">The number of records to return.</param>
        /// <returns>The query result.</returns>
        List<object[]> ExecuteReadCommand(string command, int numberOfRecordsToReturn);
    }
}
