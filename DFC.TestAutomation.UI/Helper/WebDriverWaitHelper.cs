// <copyright file="WebDriverWaitHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using DFC.TestAutomation.UI.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DFC.TestAutomation.UI.Helper
{
    public class WebDriverWaitHelper : IWebDriverWaitHelper
    {
        public WebDriverWaitHelper(IWebDriver webDriver, TimeoutSettings timeoutConfiguration, IJavaScriptHelper javascriptHelper)
        {
            this.WebDriver = webDriver;
            this.TimeoutConfiguration = timeoutConfiguration;
            this.WebDriverImplicitWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(this.TimeoutConfiguration.ImplicitWait));
            this.WebDriverNavigationWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(this.TimeoutConfiguration.PageNavigation));
            this.JavascriptHelper = javascriptHelper;
        }

        public WebDriverWait WebDriverImplicitWait { get; private set; }

        public WebDriverWait WebDriverNavigationWait { get; private set; }

        private IWebDriver WebDriver { get; set; }

        private TimeoutSettings TimeoutConfiguration { get; set; }

        private IJavaScriptHelper JavascriptHelper { get; set; }

        public void WaitForElementToBePresent(By locator)
        {
            this.WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }

        public void WaitForElementToBeDisplayed(By locator)
        {
            this.WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementToContainText(By locator, string text)
        {
            this.WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }

        public void WaitForElementToBeClickable(By locator)
        {
            this.WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public void WaitForPageToLoad()
        {
            this.WebDriverNavigationWait.Until(driver => this.JavascriptHelper.IsDocumentReady());
        }

        public void SetImplicitWait(int milliseconds)
        {
            this.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(milliseconds);
        }

        public void ResetImplicitWait()
        {
            this.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(this.TimeoutConfiguration.ImplicitWait);
        }
    }
}
