using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.Helper
{
    public class JavaScriptHelper : IJavaScriptHelper
    {
        private IWebDriver WebDriver { get; set; }

        public JavaScriptHelper(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
        }

        public bool IsDocumentReady()
        {
            return this.ExecuteScript("return document.readyState").Equals("complete");
        }

        public void ClickElement(By locator)
        {
            var webElement = WebDriver.FindElement(locator);
            this.ExecuteScript("arguments[0].click();", webElement);
        }

        public void ScrollElementIntoView(IWebElement webElement)
        {
            ExecuteScript("arguments[0].scrollIntoView({ inline: 'center' });", webElement);
        }

        public object ExecuteScript(string javascript, IWebElement webElement)
        {
            return ((IJavaScriptExecutor)WebDriver).ExecuteScript(javascript, webElement);
        }

        public object ExecuteScript(string javascript, By locator)
        {
            var webElement = WebDriver.FindElement(locator);
            return ExecuteScript(javascript, webElement);
        }

        public object ExecuteScript(string javascript)
        {
            return ((IJavaScriptExecutor)WebDriver).ExecuteScript(javascript);
        }
    }
}
