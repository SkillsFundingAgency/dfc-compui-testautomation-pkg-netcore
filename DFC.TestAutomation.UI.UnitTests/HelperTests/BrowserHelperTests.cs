// <copyright file="BrowserHelperTests.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using DFC.TestAutomation.UI.Helper;
using System.Configuration;
using Xunit;

namespace DFC.TestAutomation.UI.UnitTests.HelperTests
{
    public class BrowserHelperTests
    {
        [Fact]
        public void UnrecognisedBrowserName()
        {
            Assert.Throws<ConfigurationErrorsException>(() => new BrowserHelper("unrecognised-browser-name"));
        }

        [Theory]
        [InlineData("chrome")]
        [InlineData(" chrome ")]
        [InlineData("cHroMe")]
        public void RecognisedBrowserName(string browserName)
        {
            _ = new BrowserHelper(browserName);
        }

        [Theory]
        [InlineData("chrome", BrowserType.Chrome)]
        [InlineData("browserstack", BrowserType.BrowserStack)]
        [InlineData("firefox", BrowserType.Firefox)]
        [InlineData("ie", BrowserType.InternetExplorer)]
        public void GetBrowserType(string browserName, BrowserType browserType)
        {
            var browserHelper = new BrowserHelper(browserName);
            Assert.Equal(browserType, browserHelper.GetBrowserType());
        }

        [Theory]
        [InlineData("browserstack", true)]
        [InlineData("chrome", false)]
        [InlineData("firefox", false)]
        [InlineData("ie", false)]
        public void IsExecutingInBrowserStack(string browserName, bool isExecutingInBrowserStack)
        {
            var browserHelper = new BrowserHelper(browserName);
            Assert.Equal(isExecutingInBrowserStack, browserHelper.IsExecutingInBrowserStack());
        }
    }
}
