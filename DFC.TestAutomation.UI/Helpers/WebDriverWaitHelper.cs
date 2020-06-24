using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.TestAutomation.UI.Helpers
{
    public class WebDriverWaitHelper
    {
        private readonly IWebDriver _webDriver;
        private readonly TimeOutConfig _timeOutConfig;
        private readonly OpenQA.Selenium.Support.UI.WebDriverWait _implicitWait;
        private readonly OpenQA.Selenium.Support.UI.WebDriverWait _pagenavigationWait;

        public WebDriverWaitHelper(IWebDriver webDriver, TimeOutConfig timeOutConfig)
        {
            _webDriver = webDriver;
            _timeOutConfig = timeOutConfig;
            _implicitWait = WebDriverWait(timeOutConfig.ImplicitWait);
            _pagenavigationWait = WebDriverWait(timeOutConfig.PageNavigation);
        }

        internal void WaitForElementToBePresent(By locator) => _implicitWait.Until(ExpectedConditions.ElementExists(locator));

        internal void WaitForElementToBeDisplayed(By locator) => _implicitWait.Until(ExpectedConditions.ElementIsVisible(locator));

        internal void WaitForElementToBeClickable(By locator) => _implicitWait.Until(ExpectedConditions.ElementToBeClickable(locator));

        internal void WaitForPageToLoad() => _pagenavigationWait.Until(driver => IsDocumentReady(driver));

        internal void TurnOnImplicitWaits() => _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_timeOutConfig.ImplicitWait);

        private bool IsDocumentReady(IWebDriver driver) => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");

        private OpenQA.Selenium.Support.UI.WebDriverWait WebDriverWait(int timespan) => new OpenQA.Selenium.Support.UI.WebDriverWait(_webDriver, TimeSpan.FromSeconds(timespan));
    }
}
