// <copyright file="FormHelperTests.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using DFC.TestAutomation.UI.Helper;
using DFC.TestAutomation.UI.Settings;
using FakeItEasy;
using OpenQA.Selenium;
using Xunit;

namespace DFC.TestAutomation.UI.UnitTests.HelperTests.HelperLibraryTests
{
    public class FormHelperTests
    {
        public FormHelperTests()
        {
            this.WebElement = A.Fake<IWebElement>();
            var webDriverWaitHelper = A.Fake<IWebDriverWaitHelper>();
            this.WebDriver = A.Fake<IWebDriver>();
            var retryHelper = new RetryHelper(this.RetrySettings);
            var javascriptHelper = A.Fake<JavaScriptHelper>();
            A.CallTo(() => javascriptHelper.ScrollElementIntoView(A<IWebElement>._)).DoesNothing();
            A.CallTo(() => webDriverWaitHelper.WaitForPageToLoad()).DoesNothing();
            A.CallTo(() => this.WebDriver.FindElement(A<By>._)).Returns(this.WebElement);
            this.FormHelper = new FormHelper(this.WebDriver, webDriverWaitHelper, retryHelper, javascriptHelper);
        }

        public IWebElement WebElement { get; set; }

        public IWebDriver WebDriver { get; set; }

        public FormHelper FormHelper { get; set; }

        public RetrySettings RetrySettings { get; } = new RetrySettings()
        {
            ExplicitWaitInSeconds = 1,
            NumberOfRetries = 1,
        };

        [Fact]
        public void SelectRadioButton()
        {

        }
    }
}
