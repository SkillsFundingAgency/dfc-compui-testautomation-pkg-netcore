using DFC.TestAutomation.UI.TestSupport;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.Hooks.BeforeScenario
{
    [Binding]
    public class FileSetup
    {
        private readonly ObjectContext _objectContext;
        public FileSetup(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
        }

        //[BeforeScenario(Order = 5)]
        public void SetUpAccessibilityFile()
        {
            string axedirectory = AppDomain.CurrentDomain.BaseDirectory
                                  + "../../"
                                  + "Project\\Accessibility\\"
                                  + DateTime.Now.ToString("dd-MM-yyyy")
                                  + "\\";

            string axeFile = Path.Combine(axedirectory, "axe.txt");

            if (!Directory.Exists(axedirectory))
            {
                Directory.CreateDirectory(axedirectory);
                if (!File.Exists(axeFile))
                {
                    File.Create(axeFile).Dispose();
                }
            }
            _objectContext.SetFile(axeFile);

        }

    }
}