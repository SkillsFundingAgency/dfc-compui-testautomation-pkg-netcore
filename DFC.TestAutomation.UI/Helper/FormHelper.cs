// <copyright file="FormHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using DFC.TestAutomation.UI.Factory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
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
        public FormHelper(IWebDriver webDriver, IWebDriverWaitHelper webDriverWaitHelper, IActionsFactory actionsFactory)
        {
            this.WebDriver = webDriver;
            this.WebDriverWaitHelper = webDriverWaitHelper;
            this.ActionsFactory = actionsFactory;
        }

        private IWebDriver WebDriver { get; set; }

        private IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        private IActionsFactory ActionsFactory { get; set; }

        /// <summary>
        /// Selects a radio button using an IWebElement. If the radio button is already selected, then it will remain selected.
        /// </summary>
        /// <param name="radioButtonElement">A radio button IWebElement.</param>
        public void SelectRadioButton(IWebElement radioButtonElement)
        {
            if (radioButtonElement == null)
            {
                throw new ArgumentNullException(nameof(radioButtonElement), "Unable to select the radio button as the web element is null.");
            }

            this.WebDriverWaitHelper.WaitForElementToBeClickable(radioButtonElement);
            this.ActionsFactory.Create().MoveToElement(radioButtonElement).Click().Perform();
        }

        /// <summary>
        /// Selects a radio button using the locator for an IWebElement. If the radio button is already selected, then it will remain selected.
        /// </summary>
        /// <param name="radioButtonLocator">The locator for an IWebElement.</param>
        public void SelectRadioButton(By radioButtonLocator)
        {
            var radioButtonElement = this.WebDriver.FindElement(radioButtonLocator);
            this.SelectRadioButton(radioButtonElement);
        }

        /// <summary>
        /// Enters text into a text editable field by using an IWebElement. Any existing text in the field will be overwritten.
        /// </summary>
        /// <param name="textEditableWebElement">A text editable field IWebElement.</param>
        /// <param name="text">The text value to enter.</param>
        public void EnterText(IWebElement textEditableWebElement, string text)
        {
            if (textEditableWebElement == null)
            {
                throw new ArgumentNullException(nameof(textEditableWebElement), "Unable to enter text into the text field as the web element is null.");
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Unable to enter text into the text field. The text parameter cannot be null or empty.");
            }

            textEditableWebElement.Clear();
            textEditableWebElement.SendKeys(text);
        }

        /// <summary>
        /// Enters text into a text editable field by using a locator for an IWebElement. Any existing text in the field will be overwritten.
        /// </summary>
        /// <param name="textEditableLocator">A text editable field locator for an IWebElement.</param>
        /// <param name="text">The text value to enter.</param>
        public void EnterText(By textEditableLocator, string text)
        {
            var textEditableWebElement = this.WebDriver.FindElement(textEditableLocator);
            this.EnterText(textEditableWebElement, text);
        }

        /// <summary>
        /// Enters an integer into a text editable field by using an IWebElement. Any existing value in the field will be overwritten.
        /// </summary>
        /// <param name="textEditableWebElement">A text editable field IWebElement.</param>
        /// <param name="integerValue">The integer value to enter.</param>
        public void EnterIntegerValue(IWebElement textEditableWebElement, int integerValue)
        {
            if (textEditableWebElement == null)
            {
                throw new ArgumentNullException(nameof(textEditableWebElement), "Unable to enter a value into the text field as the web element is null.");
            }

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
            var webElement = this.WebDriver.FindElement(selectLocator);
            var selectElement = new SelectElement(webElement);
            this.SelectByIndex(selectElement, optionIndex);
        }

        /// <summary>
        /// Selects a select option by the options index. This is determined by the 'index' attribute of the option element.
        /// </summary>
        /// <param name="selectElement">A select field IWebElement.</param>
        /// <param name="optionIndex">The option index.</param>
        public void SelectByIndex(SelectElement selectElement, int optionIndex)
        {
            if (selectElement == null)
            {
                throw new ArgumentNullException(nameof(selectElement), "Unable to select an option from the select element as the element is null.");
            }

            selectElement.SelectByIndex(optionIndex);
        }

        /// <summary>
        /// Select an option by the option value.
        /// </summary>
        /// <param name="selectLocator">A select field locator for an IWebElement.</param>
        /// <param name="optionValue">The option value.</param>
        public void SelectByValue(By selectLocator, string optionValue)
        {
            var webElement = this.WebDriver.FindElement(selectLocator);
            var selectElement = new SelectElement(webElement);
            this.SelectByValue(selectElement, optionValue);
        }

        /// <summary>
        /// Select an option by the option value.
        /// </summary>
        /// <param name="selectElement">A select field IWebElement.</param>
        /// <param name="optionValue">The option value.</param>
        public void SelectByValue(SelectElement selectElement, string optionValue)
        {
            if (selectElement == null)
            {
                throw new ArgumentNullException(nameof(selectElement), "Unable to select an option from the select element as the element is null.");
            }

            selectElement.SelectByValue(optionValue);
        }

        /// <summary>
        /// Select an option by the option text.
        /// </summary>
        /// <param name="selectLocator">A select field IWebElement.</param>
        /// <param name="optionText">The option text.</param>
        public void SelectByText(By selectLocator, string optionText)
        {
            var webElement = this.WebDriver.FindElement(selectLocator);
            var selectElement = new SelectElement(webElement);
            this.SelectByText(selectElement, optionText);
        }

        /// <summary>
        /// Select an option by the option text.
        /// </summary>
        /// <param name="selectElement">A select field locator for an IWebElement.</param>
        /// <param name="optionText">The option text.</param>
        public void SelectByText(SelectElement selectElement, string optionText)
        {
            if (selectElement == null)
            {
                throw new ArgumentNullException(nameof(selectElement), "Unable to select an option from the select element as the element is null.");
            }

            selectElement.SelectByText(optionText);
        }

        /// <summary>
        /// Checks a checkbox IWebElement. If the checkbox is already checked then no action is taken.
        /// </summary>
        /// <param name="checkboxElement">The checkbox IWebElement.</param>
        public void CheckCheckbox(IWebElement checkboxElement)
        {
            if (checkboxElement == null)
            {
                throw new ArgumentNullException(nameof(checkboxElement), "Unable to check the checkbox object as the element provided is null.");
            }

            if (checkboxElement.Displayed)
            {
                if (!checkboxElement.Selected)
                {
                    this.WebDriverWaitHelper.WaitForElementToBeClickable(checkboxElement);
                    this.ActionsFactory.Create().MoveToElement(checkboxElement).Click().Perform();
                }
            }
        }

        /// <summary>
        /// Select an option by the option attribute.
        /// </summary>
        /// <param name="selectElement">The select element.</param>
        /// <param name="attributeName">The option attribute name.</param>
        /// <param name="attribute">The option attribute value.</param>
        public void SelectByAttribute(SelectElement selectElement, string attributeName, string attribute)
        {
            if (selectElement == null)
            {
                throw new ArgumentNullException(nameof(selectElement), "Unable to select an option from the select element as the element is null.");
            }

            var selectOption = selectElement.Options.FirstOrDefault(option => option.GetAttribute(attributeName) == attribute);

            if (selectOption != null)
            {
                this.WebDriverWaitHelper.WaitForElementToBeClickable(selectOption);
                this.ActionsFactory.Create().MoveToElement(selectOption).Click().Perform();
            }
            else
            {
                throw new NotFoundException($"Unable to select the option with attribute {attributeName} : {attribute}. No such option was found.");
            }
        }
    }
}
