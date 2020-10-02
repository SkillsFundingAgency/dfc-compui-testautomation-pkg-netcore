// <copyright file="FormCompletionHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Polly;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace DFC.TestAutomation.UI.Helper
{
    public class FormCompletionHelper : IFormCompletionHelper
    {
        public FormCompletionHelper(IWebDriver webDriver, IWebDriverWaitHelper webDriverWaitHelper, IRetryHelper retryHelper, IJavaScriptHelper javascriptHelper)
        {
            this.WebDriver = webDriver;
            this.WebDriverWaitHelper = webDriverWaitHelper;
            this.RetryHelper = retryHelper;
            this.JavascriptHelper = javascriptHelper;
        }

        private IWebDriver WebDriver { get; set; }

        private IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        private IRetryHelper RetryHelper { get; set; }

        private IJavaScriptHelper JavascriptHelper { get; set; }

        public void SelectRadioButton(IWebElement element)
        {
            this.ClickElement(element);
        }

        public void SelectRadioButton(By locator)
        {
            this.ClickElement(locator);
        }

        public void EnterText(IWebElement element, string text)
        {
            element?.Clear();
            element.SendKeys(text);
        }

        public void EnterText(By locator, string text)
        {
            this.EnterText(this.WebDriver.FindElement(locator), text);
        }

        public void EnterIntegerValue(IWebElement element, int value)
        {
            this.EnterText(element, value.ToString(CultureInfo.CurrentCulture));
        }

        public void EnterIntegerValue(By locator, int value)
        {
            this.EnterText(this.WebDriver.FindElement(locator), value.ToString(CultureInfo.CurrentCulture));
        }

        public void SelectByIndex(By locator, int index)
        {
            this.SelectByIndex(this.WebDriver.FindElement(locator), index);
        }

        public void SelectByIndex(IWebElement element, int index)
        {
            new SelectElement(element).SelectByIndex(index);
        }

        public void SelectFromDropDownByValue(By locator, string value)
        {
            this.SelectFromDropDownByValue(this.WebDriver.FindElement(locator), value);
        }

        public void SelectFromDropDownByText(By locator, string text)
        {
            this.SelectFromDropDownByText(this.WebDriver.FindElement(locator), text);
        }

        public void SelectFromDropDownByValue(IWebElement element, string value)
        {
            new SelectElement(element).SelectByValue(value);
        }

        public void SelectFromDropDownByText(IWebElement element, string text)
        {
            new SelectElement(element).SelectByText(text);
        }

        public void CheckCheckbox(IWebElement element)
        {
            if (element == null)
            {
                throw new NullReferenceException("Unable to check the checkbox object as the element provided is null.");
            }

            if (element.Displayed)
            {
                if (!element.Selected)
                {
                    element.Click();
                }
            }
        }

        public void SelectFromDropDownByAttribute(By locator, string attributeKey, string attribute)
        {
            IList<IWebElement> radios = this.WebDriver.FindElements(locator);
            var radioToSelect = radios.FirstOrDefault(radio => radio.GetAttribute(attributeKey) == attribute);

            if (radioToSelect != null)
            {
                this.ClickElement(radioToSelect);
            }
        }

        private void ClickElement(By locator)
        {
            this.WebDriverWaitHelper.WaitForElementToBeClickable(locator);
            this.ClickElement(this.WebDriver.FindElement(locator));
        }

        private void ClickElement(IWebElement element)
        {
            Action beforeAction = () =>
            {
                this.WebDriver.Manage().Window.Size = new Size(1920, 1080);
            };

            Action afterAction = () =>
            {
                this.WebDriver.Manage().Window.Maximize();
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
                this.JavascriptHelper.ScrollElementIntoView(element);
                new Actions(this.WebDriver).Click(element).Perform();
                afterAction?.Invoke();
            }

            this.RetryHelper.RetryOnException(ClickAction, retryAction);
        }
    }
}
