// <copyright file="JavaScriptHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.Helper
{
    public class JavaScriptHelper : IJavaScriptHelper
    {
        public JavaScriptHelper(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
        }

        private IWebDriver WebDriver { get; set; }

        public bool IsDocumentReady()
        {
            return this.ExecuteScript("return document.readyState").Equals("complete");
        }

        public IWebElement GetParentElement(IWebElement childElement)
        {
            return this.ExecuteScript("return arguments[0].parentNode;", childElement) as IWebElement;
        }

        public void ClickElement(By locator)
        {
            var webElement = this.WebDriver.FindElement(locator);
            this.ExecuteScript("arguments[0].click();", webElement);
        }

        public void ScrollElementIntoView(IWebElement webElement)
        {
            this.ExecuteScript("arguments[0].scrollIntoView({ inline: 'center' });", webElement);
        }

        public object ExecuteScript(string javascript, IWebElement webElement)
        {
            return ((IJavaScriptExecutor)this.WebDriver).ExecuteScript(javascript, webElement);
        }

        public object ExecuteScript(string javascript, By locator)
        {
            var webElement = this.WebDriver.FindElement(locator);
            return this.ExecuteScript(javascript, webElement);
        }

        public object ExecuteScript(string javascript)
        {
            return ((IJavaScriptExecutor)this.WebDriver).ExecuteScript(javascript);
        }
    }
}
