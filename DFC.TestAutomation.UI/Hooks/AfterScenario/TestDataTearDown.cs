using DFC.TestAutomation.UI.TestSupport;
using CsvHelper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.Hooks.AfterScenario
{
    [Binding]
    public class TestDataTearDown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public TestDataTearDown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [AfterScenario(Order = 10)]
        public void CollectTestData()
        {
            try
            {
                _objectContext.SetAfterScenarioExceptions(new List<Exception>());

                DateTime dateTime = DateTime.Now;

                string fileName = dateTime.ToString("HH-mm-ss")
                       + "_"
                       + _context.ScenarioInfo.Title
                       + ".txt";
                string directory = _objectContext.GetDirectory();

                string filePath = Path.Combine(directory, fileName);

                List<TestData> records = new List<TestData>();

                var testDatas = _objectContext.GetAll();

                testDatas.ToList().ForEach(x => records.Add(new TestData { Key = x.Key, Value = testDatas[x.Key].ToString() }));

                using (var writer = new StreamWriter(filePath))
                {
                    using (var csv = new CsvWriter(writer))
                    {
                        csv.WriteRecords(records);
                        writer?.Flush();
                    }
                }
                TestContext.AddTestAttachment(filePath, fileName);
            }
            catch (Exception ex)
            {
                _objectContext.SetAfterScenarioException(ex);
            }
        }
    }
}
