// <copyright file="AxeHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// </copyright>

using OpenQA.Selenium;
using Selenium.Axe;
using System;
using System.Globalization;
using System.IO;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// Provides helper functions for all axe (web accessibility testing) related operations.
    /// </summary>
    public class AxeHelper : IAxeHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AxeHelper"/> class.
        /// </summary>
        /// <param name="webDriver">The Selenium Webdriver.</param>
        public AxeHelper(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
            string folderDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\AxeOutput\\{DateTime.Now.ToString("dd-MM-yyyy_HH-mm", CultureInfo.CurrentCulture)}";
            this.FileDirectory = $"{folderDirectory}\\AxeAnalysis.txt";
            Directory.CreateDirectory(folderDirectory);
        }

        private IWebDriver WebDriver { get; set; }

        private string FileDirectory { get; set; }

        /// <summary>
        /// Runs axe analysis on the current page. The axe results are stored in the AxeOutput folder in the base directory. If the
        /// output file does not exist it creates it. If the output already exists it is opened and amended. The output contains
        /// information on the types of violations found during the analysis.
        /// </summary>
        public void Analyse()
        {
            var axeResult = this.WebDriver.Analyze();

            using (StreamWriter sw = File.CreateText(this.FileDirectory))
            {
                sw.WriteLine("Axe analysis performed.");
                sw.WriteLine($"Current browser window: {this.WebDriver.Title}");
                sw.WriteLine("Current url: " + this.WebDriver.Url);

                if (axeResult.Violations.Length > 0)
                {
                    sw.WriteLine("Result: Violations found.");

                    for (int violationIndex = 0; violationIndex < axeResult.Violations.Length; violationIndex++)
                    {
                        var axeResultItem = axeResult.Violations[violationIndex];

                        sw.WriteLine(Environment.NewLine);
                        sw.WriteLine($"Violation {violationIndex + 1}:");
                        sw.WriteLine($"Description: {axeResultItem.Description}");
                        sw.WriteLine($"Impact: {axeResultItem.Impact}");
                        sw.WriteLine($"Help: {axeResultItem.Help}");
                        sw.WriteLine($"Help url: {axeResultItem.HelpUrl}");
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
