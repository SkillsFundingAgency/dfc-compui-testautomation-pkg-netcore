// <copyright file="ScreenshotHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using DFC.TestAutomation.UI.Extension;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Globalization;
using System.IO;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// Provides helper functions for all screenshot related operations.
    /// </summary>
    public class ScreenshotHelper : IScreenshotHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenshotHelper"/> class.
        /// </summary>
        /// <param name="context">The scenario context.</param>
        public ScreenshotHelper(ScenarioContext context)
        {
            this.Context = context;
            this.FolderDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\Screenshots\\{DateTime.Now.ToString("dd-MM-yyyy_HH-mm", CultureInfo.CurrentCulture)}";
            Directory.CreateDirectory(this.FolderDirectory);
        }

        /// <summary>
        /// Gets the scenario context.
        /// </summary>
        public ScenarioContext Context { get; }

        /// <summary>
        /// Gets the folder directory.
        /// </summary>
        public string FolderDirectory { get; private set; }

        /// <summary>
        /// Takes a screenshot of the current web browser view. The resulting screenshots can be found in the 'screenshots' folder
        /// within the base directory. The subfolder will be time stamped.
        /// </summary>
        public void TakeScreenshot()
        {
            var screenshotName = $"{DateTime.Now:HH-mm-ss}_{this.Context.StepContext.StepInfo.Text}.png";
            ITakesScreenshot screenshotHandler = this.Context.GetWebDriver() as ITakesScreenshot;
            Screenshot screenshot = screenshotHandler.GetScreenshot();
            var screenshotPath = Path.Combine(this.FolderDirectory, screenshotName);
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(screenshotPath, screenshotName);
        }
    }
}
