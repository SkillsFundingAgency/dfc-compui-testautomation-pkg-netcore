// <copyright file="WebDriverWaitHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// </copyright>

using DFC.TestAutomation.UI.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// Provides helper functions for all operations that require an implicit wait.
    /// </summary>
    public class WebDriverWaitHelper : IWebDriverWaitHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverWaitHelper"/> class.
        /// </summary>
        /// <param name="webDriver">The Selenium webdriver.</param>
        /// <param name="timeoutSettings">Timeout settings.</param>
        /// <param name="javascriptHelper">The Javascript helper.</param>
        public WebDriverWaitHelper(IWebDriver webDriver, TimeoutSettings timeoutSettings, IJavaScriptHelper javascriptHelper)
        {
            this.WebDriver = webDriver;
            this.TimeoutConfiguration = timeoutSettings;
            this.WebDriverImplicitWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(this.TimeoutConfiguration.ImplicitWait));
            this.WebDriverNavigationWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(this.TimeoutConfiguration.PageNavigation));
            this.JavascriptHelper = javascriptHelper;
        }

        private WebDriverWait WebDriverImplicitWait { get; set; }

        private WebDriverWait WebDriverNavigationWait { get; set; }

        private IWebDriver WebDriver { get; set; }

        private TimeoutSettings TimeoutConfiguration { get; set; }

        private IJavaScriptHelper JavascriptHelper { get; set; }

        /// <summary>
        /// Waits for an iframe to be vaialable and when available, the Selenium webdriver switches focus to it.
        /// </summary>
        /// <param name="locator">The iframes locator.</param>
        public void WaitForFrameToBeAvailableAndSwitchToIt(By locator)
        {
            this.WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(locator));
        }

        /// <summary>
        /// Waits for an IWebElement to be present on the current page.
        /// </summary>
        /// <param name="locator">The IWebElements locator.</param>
        public void WaitForElementToBePresent(By locator)
        {
            this.WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }

        /// <summary>
        /// Waits for an IWebElement to be present and displayed on the current page.
        /// </summary>
        /// <param name="locator">The IWebElements locator.</param>
        public void WaitForElementToBeDisplayed(By locator)
        {
            this.WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Waits for an IWebElement to be present and contain specific text on the current page.
        /// </summary>
        /// <param name="locator">The IWebElements locator.</param>
        /// <param name="text">The expected text. This is case sensitive. The value is not trimmed before being asserted on.</param>
        public void WaitForElementToContainText(By locator, string text)
        {
            this.WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }

        /// <summary>
        /// Waits for an IWebElement to be clickable. Clickable means the IWebElement is present and enabled.
        /// </summary>
        /// <param name="locator">The IWebElements locator.</param>
        public void WaitForElementToBeClickable(By locator)
        {
            this.WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        /// <summary>
        /// Waits for the page DOM to report as ready. Ready means that the document and all sub-resources have finished loading.
        /// </summary>
        public void WaitForPageToLoad()
        {
            this.WebDriverNavigationWait.Until(driver => this.JavascriptHelper.IsDocumentReady());
        }

        /// <summary>
        /// Sets the implicit wait timeout. This should be used only in cases where you wish to override the configured implicit wait.
        /// It is recommended that the reset method is called once the time sensitive operation is complete so that the implicit
        /// wait is set back to its original setting.
        /// </summary>
        /// <param name="milliseconds">Implicit wait in milliseconds.</param>
        public void SetImplicitWait(int milliseconds)
        {
            this.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(milliseconds);
        }

        /// <summary>
        /// Resets the implicit wait timeout. This is a helpful function for when the implicit wait has been altered for a particular
        /// operation. The reset sets the implicit wait back to its cofigured setting.
        /// </summary>
        public void ResetImplicitWait()
        {
            this.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(this.TimeoutConfiguration.ImplicitWait);
        }
    }
}
