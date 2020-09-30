﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DFC.TestAutomation.UI.Helpers
{
    public interface IWebDriverWaitHelper
    {
        WebDriverWait WebDriverImplicitWait { get; }

        WebDriverWait WebDriverNavigationWait { get; }

        void SetImplicitWait(int milliseconds);

        void ResetImplicitWait();

        void WaitForElementToBePresent(By locator);

        void WaitForElementToContainText(By locator, string text);

        void WaitForElementToBeDisplayed(By locator);

        void WaitForElementToBeClickable(By locator);

        void WaitForPageToLoad();
    }
}
