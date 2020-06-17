using CsvHelper.Configuration.Attributes;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class TestData
    {
        [Name("Key")]
        public string Key { get; set; }

        [Name("Value")]
        public string Value { get; set; }
    }
}
