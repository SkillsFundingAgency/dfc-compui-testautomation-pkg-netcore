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
        public ScenarioContext Context { get; set; }

        public string FolderDirectory { get; set; }

        public ScreenshotHelper(ScenarioContext context)
        {
            this.Context = context;
            this.FolderDirectory = $"{ AppDomain.CurrentDomain.BaseDirectory }\\Screenshots\\{ DateTime.Now.ToString("dd-MM-yyyy_HH-mm", CultureInfo.CurrentCulture) }";
            Directory.CreateDirectory(this.FolderDirectory);
        }

        public void TakeScreenShot()
        {
            string screenshotName = $"{ DateTime.Now:HH-mm-ss}_{ this.Context.StepContext.StepInfo.Text }.png";
            ITakesScreenshot screenshotHandler = this.Context.GetWebDriver() as ITakesScreenshot;
            Screenshot screenshot = screenshotHandler.GetScreenshot();
            String screenshotPath = Path.Combine(this.FolderDirectory, screenshotName);
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(screenshotPath, screenshotName);
        }
    }
}
