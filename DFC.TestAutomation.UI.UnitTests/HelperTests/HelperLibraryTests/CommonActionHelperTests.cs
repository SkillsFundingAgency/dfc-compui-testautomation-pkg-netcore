// <copyright file="CommonActionHelperTests.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using DFC.TestAutomation.UI.Helper;
using DFC.TestAutomation.UI.Settings;
using FakeItEasy;
using OpenQA.Selenium;
using System;
using Xunit;

namespace DFC.TestAutomation.UI.UnitTests.HelperTests.HelperLibraryTests
{
    public class CommonActionHelperTests
    {
        public CommonActionHelperTests()
        {
            var webElement = A.Fake<IWebElement>();
            A.CallTo(() => webElement.Text).Returns("My faked element returns this text");

            var webDriverWaitHelper = A.Fake<IWebDriverWaitHelper>();
            A.CallTo(() => webDriverWaitHelper.WaitForPageToLoad()).DoesNothing();

            var webDriver = A.Fake<IWebDriver>();
            A.CallTo(() => webDriver.FindElement(A<By>.Ignored)).Returns(webElement);

            var retryHelper = new RetryHelper(this.RetrySettings);
            this.CommonActionHelper = new CommonActionHelper(webDriver, webDriverWaitHelper, retryHelper);
        }

        public RetrySettings RetrySettings { get; } = new RetrySettings()
        {
            ExplicitWaitInSeconds = 1,
            NumberOfRetries = 1,
        };

        public CommonActionHelper CommonActionHelper { get; set; }

        [Theory]
        [InlineData("m")]
        [InlineData("my")]
        [InlineData("My")]
        [InlineData("My faked element returns this text")]
        [InlineData("my faked element returns this text ")]
        [InlineData(" My faked element returns this text ")]
        public void ElementContainsText(string expectedText)
        {
            Assert.True(this.CommonActionHelper.ElementContainsText(By.Id("id"), expectedText));
        }

        [Theory]
        [InlineData("My REAL element returns this text")]
        [InlineData("My faked element returns this text and some more")]
        public void ElementDoesNotContainText(string expectedText)
        {
            Assert.False(this.CommonActionHelper.ElementContainsText(By.Id("id"), expectedText));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ElementContainsEmptyText(string expectedText)
        {
            Assert.Throws<InvalidOperationException>(() => this.CommonActionHelper.ElementContainsText(By.Id("id"), expectedText));
        }
    }
}
