// <copyright file="FormHelper.cs" company="PlaceholderCompany">
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
    /// <summary>
    /// Provides helper functions for all web form related operations.
    /// </summary>
    public class FormHelper : IFormHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormHelper"/> class.
        /// </summary>
        /// <param name="webDriver">The Selenium Webdriver.</param>
        /// <param name="webDriverWaitHelper">The Selenium Webdriver wait helper.</param>
        /// <param name="retryHelper">The Retry helper.</param>
        /// <param name="javascriptHelper">The Javascript helper.</param>
        public FormHelper(IWebDriver webDriver, IWebDriverWaitHelper webDriverWaitHelper, IRetryHelper retryHelper, IJavaScriptHelper javascriptHelper)
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

        /// <summary>
        /// Selects a radio button using an IWebElement. If the radio button is already selected, then it will remain selected.
        /// </summary>
        /// <param name="radioButtonElement">A radio button IWebElement.</param>
        public void SelectRadioButton(IWebElement radioButtonElement)
        {
            this.ClickElement(radioButtonElement);
        }

        /// <summary>
        /// Selects a radio button using the locator for an IWebElement. If the radio button is already selected, then it will remain selected.
        /// </summary>
        /// <param name="radioButtonLocator">The locator for an IWebElement.</param>
        public void SelectRadioButton(By radioButtonLocator)
        {
            this.ClickElement(radioButtonLocator);
        }

        /// <summary>
        /// Enters text into a text editable field by using an IWebElement. Any existing text in the field will be overwritten.
        /// </summary>
        /// <param name="textEditableWebElement">A text editable field IWebElement.</param>
        /// <param name="text">The text value to enter.</param>
        public void EnterText(IWebElement textEditableWebElement, string text)
        {
            textEditableWebElement?.Clear();
            textEditableWebElement.SendKeys(text);
        }

        /// <summary>
        /// Enters text into a text editable field by using a locator for an IWebElement. Any existing text in the field will be overwritten.
        /// </summary>
        /// <param name="textEditableLocator">A text editable field locator for an IWebElement.</param>
        /// <param name="text">The text value to enter.</param>
        public void EnterText(By textEditableLocator, string text)
        {
            this.EnterText(this.WebDriver.FindElement(textEditableLocator), text);
        }

        /// <summary>
        /// Enters an integer into a text editable field by using an IWebElement. Any existing value in the field will be overwritten.
        /// </summary>
        /// <param name="textEditableWebElement">A text editable field IWebElement.</param>
        /// <param name="integerValue">The integer value to enter.</param>
        public void EnterIntegerValue(IWebElement textEditableWebElement, int integerValue)
        {
            this.EnterText(textEditableWebElement, integerValue.ToString(CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Enters an integer into a text editable field by using a locator for an IWebElement. Any existing value in the field will be overwritten.
        /// </summary>
        /// <param name="textEditableLocator">A text editable field locator for an IWebElement.</param>
        /// <param name="integerValue">The integer value to enter.</param>
        public void EnterIntegerValue(By textEditableLocator, int integerValue)
        {
            this.EnterText(this.WebDriver.FindElement(textEditableLocator), integerValue.ToString(CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Selects a select option by the options index. This is determined by the 'index' attribute of the option element.
        /// </summary>
        /// <param name="selectLocator">A select field locator for an IWebElement.</param>
        /// <param name="optionIndex">The option index.</param>
        public void SelectByIndex(By selectLocator, int optionIndex)
        {
            this.SelectByIndex(this.WebDriver.FindElement(selectLocator), optionIndex);
        }

        /// <summary>
        /// Selects a select option by the options index. This is determined by the 'index' attribute of the option element.
        /// </summary>
        /// <param name="selectElement">A select field IWebElement.</param>
        /// <param name="optionIndex">The option index.</param>
        public void SelectByIndex(IWebElement selectElement, int optionIndex)
        {
            new SelectElement(selectElement).SelectByIndex(optionIndex);
        }

        /// <summary>
        /// Select an option by the option value.
        /// </summary>
        /// <param name="selectLocator">A select field locator for an IWebElement.</param>
        /// <param name="optionValue">The option value.</param>
        public void SelectByValue(By selectLocator, string optionValue)
        {
            this.SelectByValue(this.WebDriver.FindElement(selectLocator), optionValue);
        }

        /// <summary>
        /// Select an option by the option value.
        /// </summary>
        /// <param name="selectElement">A select field IWebElement.</param>
        /// <param name="optionValue">The option value.</param>
        public void SelectByValue(IWebElement selectElement, string optionValue)
        {
            new SelectElement(selectElement).SelectByValue(optionValue);
        }

        /// <summary>
        /// Select an option by the option text.
        /// </summary>
        /// <param name="selectElement">A select field IWebElement.</param>
        /// <param name="optionText">The option text.</param>
        public void SelectByText(By selectElement, string optionText)
        {
            this.SelectByText(this.WebDriver.FindElement(selectElement), optionText);
        }

        /// <summary>
        /// Select an option by the option text.
        /// </summary>
        /// <param name="selectLocator">A select field locator for an IWebElement.</param>
        /// <param name="optionText">The option text.</param>
        public void SelectByText(IWebElement selectLocator, string optionText)
        {
            new SelectElement(selectLocator).SelectByText(optionText);
        }

        /// <summary>
        /// Checks a checkbox IWebElement. If the checkbox is already checked then no action is taken.
        /// </summary>
        /// <param name="checkboxElement">The checkbox IWebElement.</param>
        public void CheckCheckbox(IWebElement checkboxElement)
        {
            if (checkboxElement == null)
            {
                throw new NullReferenceException("Unable to check the checkbox object as the element provided is null.");
            }

            if (checkboxElement.Displayed)
            {
                if (!checkboxElement.Selected)
                {
                    checkboxElement.Click();
                }
            }
        }

        /// <summary>
        /// Select an option by the option attribute.
        /// </summary>
        /// <param name="selectLocator">The select locator for an IWebElement.</param>
        /// <param name="attributeKey">The option attribute key.</param>
        /// <param name="attribute">The option attribute value.</param>
        public void SelectByAttribute(By selectLocator, string attributeKey, string attribute)
        {
            IList<IWebElement> radios = this.WebDriver.FindElements(selectLocator);
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
