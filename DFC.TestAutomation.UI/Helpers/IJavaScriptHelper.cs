﻿using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.Helpers
{
    public interface IJavaScriptHelper
    {
        bool IsDocumentReady();

        void ClickElement(By locator);

        object ExecuteScript(string javascript, IWebElement webElement);

        object ExecuteScript(string javascript, By locator);

        object ExecuteScript(string javascript);
    }
}
