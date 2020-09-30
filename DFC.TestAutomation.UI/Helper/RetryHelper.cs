using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Polly;
using System;
using System.Drawing;

namespace DFC.TestAutomation.UI.Helper
{
    public class RetryHelper : IRetryHelper
    {
        private IWebDriver WebDriver { get; set; }
        public TimeSpan[] SleepDurations { get; set; }
        public IJavaScriptHelper JavascriptHelper { get; set; }

        public RetryHelper(IWebDriver webDriver, IJavaScriptHelper javascriptHelper)
        {
            WebDriver = webDriver;
            SleepDurations = new TimeSpan[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3) };
            this.JavascriptHelper = javascriptHelper;
        }

        public Action<Exception, TimeSpan, int, Context> CreateRetryAction(Action func)
        {
            return (exception, timeSpan, retryCount, context) =>
            {
                func.Invoke();
            };
        }

        public T RetryOnException<T>(Func<T> action, Action<Exception, TimeSpan, int, Context> retryAction)
        {
            return Policy.Handle<Exception>().WaitAndRetry(this.SleepDurations, retryAction).Execute(action);
        }

        public T RetryOnException<T>(Func<T> action)
        {
            return Policy.Handle<Exception>().WaitAndRetry(this.SleepDurations).Execute(action);
        }

        internal void RetryOnElementClickInterceptedException(IWebElement element)
        {

            Action beforeAction = null, afterAction = null;
            Policy
                 .Handle<ElementClickInterceptedException>().Or<WebDriverException>()
                 .WaitAndRetry(this.SleepDurations, (exception, timeSpan, retryCount, context) =>
                 {
                     if(retryCount.Equals(1))
                     {
                         beforeAction = () => WebDriver.Manage().Window.Size = new Size(1920, 1080);
                         afterAction = () => WebDriver.Manage().Window.Maximize();
                     }
                 })
                 .Execute(() =>
                 {
                     beforeAction?.Invoke();
                     this.JavascriptHelper.ExecuteScript("arguments[0].scrollIntoView({ inline: 'center' });", element);
                     new Actions(WebDriver).Click(element).Perform();
                     afterAction?.Invoke();
                 });
        }
    }
}