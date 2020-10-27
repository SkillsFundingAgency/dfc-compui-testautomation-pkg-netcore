// <copyright file="BrowserHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// Provides helper functions for all web browser related operations.
    /// </summary>
    public class BrowserHelper : IBrowserHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserHelper"/> class.
        /// </summary>
        /// <param name="browserName">The name of the browser.</param>
        public BrowserHelper(string browserName)
        {
            this.BrowserName = browserName?.ToLower(CultureInfo.CurrentCulture).Trim();

            if (!this.BrowserIndex.ContainsKey(this.BrowserName))
            {
                throw new InvalidOperationException($"Unable to initialise the BrowserHelper class as the browser '{this.BrowserName}' was not recognised.");
            }
        }

        private string BrowserName { get; set; }

        private Dictionary<string, BrowserType> BrowserIndex { get; } = new Dictionary<string, BrowserType>()
        {
            { "browserstack", BrowserType.BrowserStack },
            { "cloud", BrowserType.BrowserStack },
            { "zapProxyChrome", BrowserType.Chrome },
            { "ie", BrowserType.InternetExplorer },
            { "internetexplorer", BrowserType.InternetExplorer },
            { "firefox", BrowserType.Firefox },
            { "mozillafirefox", BrowserType.Firefox },
            { "chrome", BrowserType.Chrome },
            { "googlechrome", BrowserType.Chrome },
            { "local", BrowserType.Chrome },
            { "chromeheadless", BrowserType.Chrome },
            { "headlessbrowser", BrowserType.Chrome },
            { "headless", BrowserType.Chrome },
        };

        /// <summary>
        /// Gets a BrowserType.
        /// </summary>
        /// <returns>A BrowserType based on the browser name.</returns>
        public BrowserType GetBrowserType()
        {
            return this.BrowserIndex[this.BrowserName];
        }

        /// <summary>
        /// Assesses whether the current test execution is being hosted in BrowserStack.
        /// </summary>
        /// <returns>True in the case where the current test execution is hosted in BrowserStack. False if the current execution is not hosted in BrowserStack.</returns>
        public bool IsExecutingInBrowserStack()
        {
            return this.BrowserIndex[this.BrowserName].Equals(BrowserType.BrowserStack);
        }
    }
}
