// <copyright file="ISqlDatabaseHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace DFC.TestAutomation.UI.Helper
{
    public interface ISqlDatabaseHelper
    {
        int ExecuteWriteCommand(string query);

        List<object[]> ExecuteReadCommand(string query, int numberOfRecordsToReturn);
    }
}
