// <copyright file="IWebDriverWaitHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.Helper
{
    public interface IWebDriverWaitHelper
    {
        void SetImplicitWait(int milliseconds);

        void ResetImplicitWait();

        void WaitForElementToBePresent(By locator);

        void WaitForFrameToBeAvailableAndSwitchToIt(By locator);

        void WaitForElementToContainText(By locator, string text);

        void WaitForElementToBeDisplayed(By locator);

        void WaitForElementToBeClickable(By locator);

        void WaitForPageToLoad();
    }
}
