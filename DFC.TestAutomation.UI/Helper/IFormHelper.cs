// <copyright file="IFormCompletionHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.Helper
{
    public interface IFormHelper
    {
        void SelectRadioButton(IWebElement element);

        void SelectRadioButton(By locator);

        void EnterText(IWebElement element, string text);

        void EnterText(By locator, string text);

        void EnterIntegerValue(IWebElement element, int value);

        void EnterIntegerValue(By locator, int value);

        void SelectByIndex(By locator, int index);

        void SelectByIndex(IWebElement element, int index);

        void SelectByValue(By locator, string value);

        void SelectByText(By locator, string text);

        void SelectByValue(IWebElement element, string value);

        void SelectByText(IWebElement element, string text);

        void CheckCheckbox(IWebElement element);

        void SelectByAttribute(By locator, string attributeKey, string attribute);
    }
}
