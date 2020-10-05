﻿// <copyright file="ICommonActionHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace DFC.TestAutomation.UI.Helper
{
    public interface ICommonActionHelper
    {
        bool VerifyPage(By locator, string expected);

        string GetAttributeValue(By locator, string attributeKey);

        string GetTextFromElements(By locator);

        int GetCountOfElements(By locator);

        bool IsElementPresent(By locator);

        bool IsElementDisplayed(By locator);

        void SetElementFocus(By locator);

        void SwitchToFrame(By locator);

        string GetText(By locator);

        string GetText(IWebElement webElement);

        Uri GetUrl();

        IWebElement GetLinkByText(By locator, string linkText);

        IWebElement GetLinkContainingText(By locator, string linkText);

        string GetTableRowContainingCellWithText(By tableIdentifier, string cellText);

        List<IWebElement> GetAllTableRows(By tableIdentifier);

        List<string> GetAllSelectOptions(By locator);

        void WaitForElementToContainText(By locator, string text);
    }
}
