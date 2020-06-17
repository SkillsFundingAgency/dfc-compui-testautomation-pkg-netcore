using OpenQA.Selenium;
using System.IO;
using Selenium.Axe;

namespace DFC.TestAutomation.UI.Helpers
{
    public class AxeHelper
    {
        private readonly IWebDriver _webDriver;
        private int _i;

        public AxeHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _i = 0;
        }

        public void AxeAnalyzer(IWebDriver webDriver, string axeFile)
        {

            using (StreamWriter sw = new StreamWriter(axeFile, append: true))
            {

                AxeResult results = _webDriver.Analyze();

                if (results.Passes.Length > 0)
                {
                    sw.WriteLine("Service: " +_webDriver.Title);
                    while (_i < (_webDriver.Title.Length+9))
                    {
                        sw.Write("=");
                        _i++;
                    }
                    sw.WriteLine("\n");
                    sw.WriteLine("URL: " +_webDriver.Url.ToLower());

                    if (results.Violations.Length > 0)
                    {
                        foreach (var violation in results.Violations)
                        {
                            sw.WriteLine("Id: " + violation.Id);
                            sw.WriteLine("Description: " + violation.Description);
                            sw.WriteLine("Impact: " + violation.Impact);
                            sw.WriteLine("Help: " + violation.Help);
                            sw.WriteLine("HelpURL: " + violation.HelpUrl);
                            foreach (var node in violation.Nodes)
                            {
                                sw.WriteLine(node.Html);
                                sw.WriteLine("\n");
                            }
                        }
                    }
                }
            }
        }

    }
}
