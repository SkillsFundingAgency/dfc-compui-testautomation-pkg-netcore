using OpenQA.Selenium;
using System.IO;
using Selenium.Axe;
using System.Linq;
using System;
using System.Globalization;

namespace DFC.TestAutomation.UI.Helper
{
    public class AxeHelper : IAxeHelper
    {
        private IWebDriver WebDriver { get; set; }

        private string FileDirectory { get; set; }

        public AxeHelper(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
            string folderDirectory = $"{ AppDomain.CurrentDomain.BaseDirectory }\\AxeOutput\\{ DateTime.Now.ToString("dd-MM-yyyy_HH-mm", CultureInfo.CurrentCulture) }";
            this.FileDirectory = $"{ folderDirectory }\\AxeAnalysis.txt";
            Directory.CreateDirectory(folderDirectory);
            File.CreateText(this.FileDirectory);
        }

        public void Analyse()
        {
            var axeResult = WebDriver.Analyze();

            using (StreamWriter sw = new StreamWriter(this.FileDirectory, true))
            {
                sw.WriteLine("Axe analysis performed.");
                sw.WriteLine($"Current browser window: { WebDriver.Title }");
                sw.WriteLine("Current url: " + WebDriver.Url);

                if (axeResult.Violations.Count() > 0)
                {
                    sw.WriteLine("Result: Violations found.");

                    for (int violationIndex = 0; violationIndex < axeResult.Violations.Count(); violationIndex++)
                    {
                        var axeResultItem = axeResult.Violations[violationIndex];

                        sw.WriteLine(Environment.NewLine);
                        sw.WriteLine($"Violation { violationIndex + 1 }:");
                        sw.WriteLine($"Description: { axeResultItem.Description }");
                        sw.WriteLine($"Impact: { axeResultItem.Impact }");
                        sw.WriteLine($"Help: { axeResultItem.Help }");
                        sw.WriteLine($"Help url: { axeResultItem.HelpUrl }");
                    }
                }
                else
                {
                    sw.WriteLine("Result: No violations found.");
                }

                sw.WriteLine(Environment.NewLine);
            }
        }
    }
}
