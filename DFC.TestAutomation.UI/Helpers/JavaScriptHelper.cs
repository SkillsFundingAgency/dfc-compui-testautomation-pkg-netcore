using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.Helpers
{
    public class JavaScriptHelper
    {
        private readonly IWebDriver _webDriver;

        public JavaScriptHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void ClickElement(By locator)
        {
            var webElement = _webDriver.FindElement(locator);
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].click();", webElement);
        }

        public object ExecuteScript(string javascript, IWebElement webElement)
        {
            return ((IJavaScriptExecutor)_webDriver).ExecuteScript(javascript, webElement);
        }

        public object ExecuteScript(string javascript, By locator)
        {
            var webElement = _webDriver.FindElement(locator);
            return ExecuteScript(javascript, webElement);
        }

        public object ExecuteScript(string javascript)
        {
            return ((IJavaScriptExecutor)_webDriver).ExecuteScript(javascript);
        }
    }
}
