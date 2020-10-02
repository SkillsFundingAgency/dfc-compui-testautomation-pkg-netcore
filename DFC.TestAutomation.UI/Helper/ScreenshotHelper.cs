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
    public class ScreenshotHelper : IScreenshotHelper
    {
        public ScreenshotHelper(ScenarioContext context)
        {
            this.Context = context;
            this.FolderDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\Screenshots\\{DateTime.Now.ToString("dd-MM-yyyy_HH-mm", CultureInfo.CurrentCulture)}";
            Directory.CreateDirectory(this.FolderDirectory);
        }

        public ScenarioContext Context { get; }

        public string FolderDirectory { get; set; }

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
