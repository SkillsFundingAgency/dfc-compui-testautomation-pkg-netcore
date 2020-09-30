using System.Collections.Generic;

namespace DFC.TestAutomation.UI.Helper
{
    public interface ISqlDatabaseConnectionHelper
    {
        int ExecuteSqlCommand(string query);

        int ExecuteSqlCommand(string query, Dictionary<string, string> parameters);

        List<object[]> ReadDataFromDataBase(string query, int numberOfRecordsToReturn);
    }
}
