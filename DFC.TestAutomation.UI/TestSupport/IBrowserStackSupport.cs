// <copyright file="IBrowserStackSupport.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace DFC.TestAutomation.UI.TestSupport
{
    /// <summary>
    /// An interface containing definitions for for all BrowserStack related operations.
    /// </summary>
    public interface IBrowserStackSupport
    {
        /// <summary>
        /// Creates an instance of the Selenium remote webdriver.
        /// </summary>
        /// <returns>The Selenium remote webdriver.</returns>
        IWebDriver CreateRemoteWebDriver();

        /// <summary>
        /// Sends a message to the BrowserStack service.
        /// </summary>
        /// <param name="remoteWebDriver">The Selenium remote webdriver.</param>
        /// <param name="status">The message status.</param>
        /// <param name="message">The message body.</param>
        void SendMessage(RemoteWebDriver remoteWebDriver, string status, string message);
    }
}
