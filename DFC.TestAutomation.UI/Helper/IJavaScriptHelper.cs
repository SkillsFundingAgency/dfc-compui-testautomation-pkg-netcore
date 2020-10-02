// <copyright file="IJavaScriptHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.Helper
{
    public interface IJavaScriptHelper
    {
        bool IsDocumentReady();

        IWebElement GetParentElement(IWebElement childElement);

        void ClickElement(By locator);

        void ScrollElementIntoView(IWebElement webElement);

        object ExecuteScript(string javascript, params IWebElement[] webElements);

        object ExecuteScript(string javascript, params By[] locators);

        object ExecuteScript(string javascript);
    }
}
