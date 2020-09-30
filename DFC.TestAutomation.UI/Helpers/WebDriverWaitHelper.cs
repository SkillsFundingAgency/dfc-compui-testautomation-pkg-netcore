using DFC.TestAutomation.UI.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DFC.TestAutomation.UI.Helpers
{
    public class WebDriverWaitHelper : IWebDriverWaitHelper
    {
        private IWebDriver WebDriver { get; set; }
        private TimeoutConfiguration TimeoutConfiguration { get; set; }
        public WebDriverWait WebDriverImplicitWait { get; private set; }
        public WebDriverWait WebDriverNavigationWait { get; private set; }
        private IJavaScriptHelper JavascriptHelper { get; set; }

        public WebDriverWaitHelper(IWebDriver webDriver, TimeoutConfiguration timeoutConfiguration, IJavaScriptHelper javascriptHelper)
        {
            this.WebDriver = webDriver;
            this.TimeoutConfiguration = timeoutConfiguration;
            WebDriverImplicitWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutConfiguration.ImplicitWait));
            WebDriverNavigationWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutConfiguration.PageNavigation));
            this.JavascriptHelper = javascriptHelper;
        }

        public void WaitForElementToBePresent(By locator)
        {
            WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }

        public void WaitForElementToBeDisplayed(By locator)
        {
            WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementToContainText(By locator, string text)
        {
            WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }

        public void WaitForElementToBeClickable(By locator)
        {
            WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public void WaitForPageToLoad()
        {
            WebDriverNavigationWait.Until(driver => this.JavascriptHelper.IsDocumentReady());
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
