// <copyright file="IWebDriverConfigurator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.TestSupport
{
    public interface IWebDriverConfigurator
    {
        IWebDriver Create();
    }
}
