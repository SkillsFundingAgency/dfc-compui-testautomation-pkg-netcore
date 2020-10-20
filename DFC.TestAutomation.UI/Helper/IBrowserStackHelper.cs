// <copyright file="IBrowserStackHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OpenQA.Selenium;
using System.Net.Http;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// An interface containing definitions for for all BrowserStack related operations.
    /// </summary>
    public interface IBrowserStackHelper
    {
        /// <summary>
        /// Creates an instance of the Selenium remote webdriver.
        /// </summary>
        /// <returns>The Selenium remote webdriver.</returns>
        IWebDriver CreateRemoteWebDriver();

        /// <summary>
        /// Sets the current test to failed.
        /// </summary>
        /// <param name="webDriverSessionId">The remote webdriver session id.</param>
        /// <param name="reason">The reason for the test failure.</param>
        /// <returns>A task providing information on the asynchronous operation.</returns>
        Task<HttpResponseMessage> SetTestToFailedWithReason(string webDriverSessionId, string reason);

        /// <summary>
        /// Sets the current test to passed.
        /// </summary>
        /// <param name="webDriverSessionId">The remote webdriver session id.</param>
        /// <returns>A task providing information on the asynchronous operation.</returns>
        Task<HttpResponseMessage> SetTestToPassed(string webDriverSessionId);
    }
}
