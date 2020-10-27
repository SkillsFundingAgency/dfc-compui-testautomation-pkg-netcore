// <copyright file="CommonActionHelperTests.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using DFC.TestAutomation.UI.Helper;
using DFC.TestAutomation.UI.Settings;
using FakeItEasy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace DFC.TestAutomation.UI.UnitTests.HelperTests.HelperLibraryTests
{
    public class CommonActionHelperTests
    {
        public CommonActionHelperTests()
        {
            this.WebElement = A.Fake<IWebElement>();
            var webDriverWaitHelper = A.Fake<IWebDriverWaitHelper>();
            this.WebDriver = A.Fake<IWebDriver>();
            var retryHelper = new RetryHelper(this.RetrySettings);
            A.CallTo(() => webDriverWaitHelper.WaitForPageToLoad()).DoesNothing();
            A.CallTo(() => this.WebDriver.FindElement(A<By>._)).Returns(this.WebElement);
            this.CommonActionHelper = new CommonActionHelper(this.WebDriver, webDriverWaitHelper, retryHelper);
        }

        public RetrySettings RetrySettings { get; } = new RetrySettings()
        {
            ExplicitWaitInSeconds = 1,
            NumberOfRetries = 1,
        };

        public CommonActionHelper CommonActionHelper { get; set; }

        public IWebElement WebElement { get; set; }

        public IWebDriver WebDriver { get; set; }

        [Theory]
        [InlineData("m")]
        [InlineData("my")]
        [InlineData("My")]
        [InlineData("My faked element returns this text")]
        [InlineData("my faked element returns this text ")]
        [InlineData(" My faked element returns this text ")]
        public void ElementContainsText(string expectedText)
        {
            A.CallTo(() => this.WebElement.Text).Returns("My faked element returns this text");
            Assert.True(this.CommonActionHelper.ElementContainsText(By.Id("id"), expectedText));
        }

        [Theory]
        [InlineData("My REAL element returns this text")]
        [InlineData("My faked element returns this text and some more")]
        public void ElementDoesNotContainText(string expectedText)
        {
            A.CallTo(() => this.WebElement.Text).Returns("My faked element returns this text");
            Assert.False(this.CommonActionHelper.ElementContainsText(By.Id("id"), expectedText));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ElementContainsEmptyText(string expectedText)
        {
            Assert.Throws<InvalidOperationException>(() => this.CommonActionHelper.ElementContainsText(By.Id("id"), expectedText));
        }

        [Fact]
        public void GetText()
        {
            A.CallTo(() => this.WebElement.Text).Returns("My faked element returns this text");
            Assert.Equal("My faked element returns this text", this.CommonActionHelper.GetText(this.WebElement));
        }

        [Fact]
        public void GetUrl()
        {
            A.CallTo(() => this.WebDriver.Url).Returns("https://www.aurl.com/");
            Assert.Equal(new Uri("https://www.aurl.com/"), this.CommonActionHelper.GetUrl());
        }

        [Fact]
        public void GetAttributeValueReturnsWebElementAttribute()
        {
            A.CallTo(() => this.WebElement.GetAttribute(A<string>._)).Returns("Attribute value");
            Assert.Equal("Attribute value", this.CommonActionHelper.GetAttributeValue(By.Id("id"), "attributeName"));
        }

        [Fact]
        public void GetAttributeValueCallsOnGetAttributeOnce()
        {
            this.CommonActionHelper.GetAttributeValue(By.Id("id"), "attributeName");
            A.CallTo(() => this.WebElement.GetAttribute("attributeName")).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void GetTextFromElementsReturnsEmptyString()
        {
            A.CallTo(() => this.WebDriver.FindElements(A<By>._)).Returns(new ReadOnlyCollection<IWebElement>(new List<IWebElement>()));
            Assert.Equal(string.Empty, this.CommonActionHelper.GetTextFromElements(By.Id("id")));
        }

        [Fact]
        public void GetTextFromElementsReturnsConcatenatedString()
        {
            A.CallTo(() => this.WebElement.Text).Returns("My faked element returns this text");
            var secondWebElement = A.Fake<IWebElement>();
            A.CallTo(() => secondWebElement.Text).Returns("... and this text!");
            A.CallTo(() => this.WebDriver.FindElements(A<By>._)).Returns(new ReadOnlyCollection<IWebElement>(new List<IWebElement>() { this.WebElement, secondWebElement }));
            Assert.Equal("My faked element returns this text ... and this text!", this.CommonActionHelper.GetTextFromElements(By.Id("id")));
        }

        [Fact]
        public void GetMultipleCountOfElements()
        {
            var secondWebElement = A.Fake<IWebElement>();
            var thirdWebElement = A.Fake<IWebElement>();
            A.CallTo(() => this.WebDriver.FindElements(A<By>._)).Returns(new ReadOnlyCollection<IWebElement>(new List<IWebElement>() { this.WebElement, secondWebElement, thirdWebElement }));
            Assert.Equal(3, this.CommonActionHelper.GetCountOfElements(By.Id("id")));
        }

        [Fact]
        public void GetZeroCountOfElements()
        {
            A.CallTo(() => this.WebDriver.FindElements(A<By>._)).Returns(new ReadOnlyCollection<IWebElement>(new List<IWebElement>()));
            Assert.Equal(0, this.CommonActionHelper.GetCountOfElements(By.Id("id")));
        }

        [Fact]
        public void IsElementPresentWhenNoElementsFound()
        {
            A.CallTo(() => this.WebDriver.FindElements(A<By>._)).Returns(new ReadOnlyCollection<IWebElement>(new List<IWebElement>()));
            Assert.False(this.CommonActionHelper.IsElementPresent(By.Id("id")));
        }

        [Fact]
        public void IsElementPresentWhenMultipleElementsFound()
        {
            A.CallTo(() => this.WebDriver.FindElements(A<By>._)).Returns(new ReadOnlyCollection<IWebElement>(new List<IWebElement>() { this.WebElement, this.WebElement }));
            Assert.True(this.CommonActionHelper.IsElementPresent(By.Id("id")));
        }

        [Fact]
        public void IsElementDisplayedReturnsFalseWhenElementIsNotFound()
        {
            A.CallTo(() => this.WebElement.Displayed).Throws<NoSuchElementException>();
            Assert.False(this.CommonActionHelper.IsElementDisplayed(By.Id("id")));
        }

        [Fact]
        public void IsElementDisplayedReturnsFalseWhenElementIsStale()
        {
            A.CallTo(() => this.WebElement.Displayed).Throws<StaleElementReferenceException>();
            Assert.False(this.CommonActionHelper.IsElementDisplayed(By.Id("id")));
        }

        [Fact]
        public void SetElementFocusThrowsExceptionWhenElementIsNotFound()
        {
            A.CallTo(() => this.WebDriver.FindElements(A<By>._)).Returns(new ReadOnlyCollection<IWebElement>(new List<IWebElement>()));
            Assert.Throws<NotFoundException>(() => this.CommonActionHelper.SetElementFocus(By.Id("id")));
        }

        [Fact]
        public void GetAllSelectOptionsThrowsUnexpectedTagNameException()
        {
            A.CallTo(() => this.WebElement.TagName).Returns("input");
            A.CallTo(() => this.WebDriver.FindElements(A<By>._)).Returns(new ReadOnlyCollection<IWebElement>(new List<IWebElement>() { this.WebElement }));
            Assert.Throws<UnexpectedTagNameException>(() => this.CommonActionHelper.GetAllSelectOptions(By.Id("id")));
        }

        [Fact]
        public void GetAllSelectOptionsThrowsNotFoundException()
        {
            A.CallTo(() => this.WebDriver.FindElements(A<By>._)).Returns(new ReadOnlyCollection<IWebElement>(new List<IWebElement>()));
            Assert.Throws<NotFoundException>(() => this.CommonActionHelper.GetAllSelectOptions(By.Id("id")));
        }
    }
}
