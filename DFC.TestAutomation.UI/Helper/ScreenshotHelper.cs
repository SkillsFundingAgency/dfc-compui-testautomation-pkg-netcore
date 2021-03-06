﻿// <copyright file="ScreenshotHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

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
        public ScreenshotHelper(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
            this.FolderDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\Screenshots\\{DateTime.Now.ToString("dd-MM-yyyy_HH-mm", CultureInfo.CurrentCulture)}";
            Directory.CreateDirectory(this.FolderDirectory);
        }

        public IWebDriver WebDriver { get; set; }

        private string FolderDirectory { get; set; }

        /// <summary>
        /// Takes a screenshot of the current web browser view. The resulting screenshots can be found in the 'screenshots' folder
        /// within the base directory. The subfolder will be time stamped.
        /// </summary>
        public void TakeScreenshot(ScenarioContext scenarioContext)
        {
            var screenshotName = $"{DateTime.Now:HH-mm-ss}_{scenarioContext?.StepContext.StepInfo.Text}.png";
            ITakesScreenshot screenshotHandler = this.WebDriver as ITakesScreenshot;
            Screenshot screenshot = screenshotHandler.GetScreenshot();
            var screenshotPath = Path.Combine(this.FolderDirectory, screenshotName);
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
        }
    }
}