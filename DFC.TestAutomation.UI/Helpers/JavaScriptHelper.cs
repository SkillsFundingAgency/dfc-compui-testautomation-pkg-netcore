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

        public void ExecuteScript(string javascript, IWebElement webElement)
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript(javascript, webElement);
        }

        public void ExecuteScript(string javascript, By locator)
        {
            var webElement = _webDriver.FindElement(locator);
            ExecuteScript(javascript, webElement);
        }

        public void ExecuteScript(string javascript)
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript(javascript);
        }
    }
}
