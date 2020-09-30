using NUnit.Framework.Internal.Commands;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Polly;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DFC.TestAutomation.UI.Helper
{
    public class FormCompletionHelper
    {
        private readonly IWebDriver _webDriver;
        private readonly IWebDriverWaitHelper _webDriverWaitHelper;
        private readonly IRetryHelper _retryHelper;
        private readonly IJavaScriptHelper _javascriptHelper;

        public FormCompletionHelper(IWebDriver webDriver, IWebDriverWaitHelper webDriverWaitHelper, IRetryHelper retryHelper, IJavaScriptHelper javascriptHelper)
        {
            _webDriver = webDriver;
            _webDriverWaitHelper = webDriverWaitHelper;
            _retryHelper = retryHelper;
            this._javascriptHelper = javascriptHelper;
        }

        public void SelectRadioButton(IWebElement element)
        {
            ClickElement(element);
        }

        public void SelectRadioButton(By locator)
        {
            SelectRadioButton(_webDriver.FindElement(locator));
        }

        public void ClickElement(IWebElement element)
        {
            Action beforeAction = () =>
            {
                this._webDriver.Manage().Window.Size = new Size(1920, 1080);
            };

            Action afterAction = () =>
            {
                this._webDriver.Manage().Window.Maximize();
            };

            Action<Exception, TimeSpan, int, Context> retryAction = (exception, timeSpan, retryCount, context) =>
            {
                if (retryCount > 1)
                {
                    beforeAction = null;
                    afterAction = null;
                }
            };

            void ClickAction()
            {
                beforeAction?.Invoke();
                this._javascriptHelper.ScrollElementIntoView(element);
                new Actions(this._webDriver).Click(element).Perform();
                afterAction?.Invoke();
            }

            _retryHelper.RetryOnException(ClickAction, retryAction);
        }

        public void ClickElement(By locator)
        {
            _webDriverWaitHelper.WaitForElementToBeClickable(locator);
            ClickElement(_webDriver.FindElement(locator));
        }

        public void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void EnterText(By locator, string text)
        {
            EnterText(_webDriver.FindElement(locator), text);
        }

        public void EnterText(By locator, int text)
        {
            EnterText(locator, text.ToString());
        }

        public void EnterText(IWebElement element, int value)
        {
            EnterText(element, value.ToString());
        }

        public void SelectByIndex(By @by, int index)
        {
            SelectByIndex(_webDriver.FindElement(by), index);
        }

        public void SelectFromDropDownByValue(By @by, string value)
        {
            SelectFromDropDownByValue(_webDriver.FindElement(by), value);
        }

        public void SelectFromDropDownByText(By @by, string text)
        {
            SelectFromDropDownByText(_webDriver.FindElement(by), text);
        }

        private void SelectByIndex(IWebElement element, int index)
        {
            SelectElement(element).SelectByIndex(index);
        }

        private void SelectFromDropDownByValue(IWebElement element, string value)
        {
            SelectElement(element).SelectByValue(value);
        }

        private void SelectFromDropDownByText(IWebElement element, string text)
        {
            SelectElement(element).SelectByText(text);
        }

        public void SelectCheckBox(IWebElement element)
        {
            if (element.Displayed && !element.Selected)
            {
                element.Click();
            }
        }

        public void SelectRadioOptionByForAttribute(By locator, string forAttribute)
        {
            IList<IWebElement> radios = _webDriver.FindElements(locator);
            var radioToSelect = radios.FirstOrDefault(radio => radio.GetAttribute("for") == forAttribute);

            if (radioToSelect != null)
                ClickElement(radioToSelect);
        }

        public void SelectRadioOptionByText(By locator, String text)
        {
            IList<IWebElement> radios = _webDriver.FindElements(locator);

            for (int i = 0; i < radios.Count; i++)
            {
                String str = radios.ElementAt(i).Text;
                if (str.Equals(text))
                {
                    radios.ElementAt(i).Click();
                    return;
                }
            }
        }

        private SelectElement SelectElement(IWebElement element)
        {
            return new SelectElement(element);
        }
    }
}
