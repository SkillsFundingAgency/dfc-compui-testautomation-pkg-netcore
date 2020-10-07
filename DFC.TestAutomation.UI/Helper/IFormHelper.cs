// <copyright file="IFormHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// An interface containing definitions for all form related operations.
    /// </summary>
    public interface IFormHelper
    {
        /// <summary>
        /// Selects a radio button using an IWebElement. If the radio button is already selected, then it will remain selected.
        /// </summary>
        /// <param name="radioButtonElement">A radio button IWebElement.</param>
        void SelectRadioButton(IWebElement radioButtonElement);

        /// <summary>
        /// Selects a radio button using the locator for an IWebElement. If the radio button is already selected, then it will remain selected.
        /// </summary>
        /// <param name="radioButtonLocator">The locator for an IWebElement.</param>
        void SelectRadioButton(By radioButtonLocator);

        /// <summary>
        /// Enters text into a text editable field by using an IWebElement. Any existing text in the field will be overwritten.
        /// </summary>
        /// <param name="textEditableWebElement">A text editable field IWebElement.</param>
        /// <param name="text">The text value to enter.</param>
        void EnterText(IWebElement textEditableWebElement, string text);

        /// <summary>
        /// Enters text into a text editable field by using a locator for an IWebElement. Any existing text in the field will be overwritten.
        /// </summary>
        /// <param name="textEditableLocator">A text editable field locator for an IWebElement.</param>
        /// <param name="text">The text value to enter.</param>
        void EnterText(By textEditableLocator, string text);

        /// <summary>
        /// Enters an integer into a text editable field by using an IWebElement. Any existing value in the field will be overwritten.
        /// </summary>
        /// <param name="textEditableWebElement">A text editable field IWebElement.</param>
        /// <param name="integerValue">The integer value to enter.</param>
        void EnterIntegerValue(IWebElement textEditableWebElement, int integerValue);

        /// <summary>
        /// Enters an integer into a text editable field by using a locator for an IWebElement. Any existing value in the field will be overwritten.
        /// </summary>
        /// <param name="textEditableLocator">A text editable field locator for an IWebElement.</param>
        /// <param name="integerValue">The integer value to enter.</param>
        void EnterIntegerValue(By textEditableLocator, int integerValue);

        /// <summary>
        /// Selects a select option by the options index. This is determined by the 'index' attribute of the option element.
        /// </summary>
        /// <param name="selectLocator">A select field locator for an IWebElement.</param>
        /// <param name="optionIndex">The option index.</param>
        void SelectByIndex(By selectLocator, int optionIndex);

        /// <summary>
        /// Selects a select option by the options index. This is determined by the 'index' attribute of the option element.
        /// </summary>
        /// <param name="selectElement">A select field IWebElement.</param>
        /// <param name="optionIndex">The option index.</param>
        void SelectByIndex(IWebElement selectElement, int optionIndex);

        /// <summary>
        /// Select an option by the option value.
        /// </summary>
        /// <param name="selectLocator">A select field locator for an IWebElement.</param>
        /// <param name="optionValue">The option value.</param>
        void SelectByValue(By selectLocator, string optionValue);

        /// <summary>
        /// Select an option by the option value.
        /// </summary>
        /// <param name="selectElement">A select field IWebElement.</param>
        /// <param name="optionValue">The option value.</param>
        void SelectByText(By selectElement, string optionValue);

        /// <summary>
        /// Select an option by the option text.
        /// </summary>
        /// <param name="selectElement">A select field IWebElement.</param>
        /// <param name="optionText">The option text.</param>
        void SelectByValue(IWebElement selectElement, string optionText);

        /// <summary>
        /// Select an option by the option text.
        /// </summary>
        /// <param name="selectLocator">A select field locator for an IWebElement.</param>
        /// <param name="optionText">The option text.</param>
        void SelectByText(IWebElement selectLocator, string optionText);

        /// <summary>
        /// Checks a checkbox IWebElement. If the checkbox is already checked then no action is taken.
        /// </summary>
        /// <param name="checkboxElement">The checkbox IWebElement.</param>
        void CheckCheckbox(IWebElement checkboxElement);

        /// <summary>
        /// Select an option by the option attribute.
        /// </summary>
        /// <param name="selectLocator">The select locator for an IWebElement.</param>
        /// <param name="attributeName">The option attribute name.</param>
        /// <param name="attribute">The option attribute value.</param>
        void SelectByAttribute(By selectLocator, string attributeName, string attribute);
    }
}
