// <copyright file="FormHelperTests.cs" company="National Careers Service">
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

namespace DFC.TestAutomation.UI.UnitTests.HelperTests
{
    public class FormHelperTests
    {
        public FormHelperTests()
        {
            this.WebElement = A.Fake<IWebElement>();
            this.WebDriverWaitHelper = A.Fake<IWebDriverWaitHelper>();
            this.WebDriver = A.Fake<IWebDriver>();
            A.CallTo(() => this.WebDriverWaitHelper.WaitForElementToBeClickable(A<IWebElement>._)).DoesNothing();
            A.CallTo(() => this.WebDriver.FindElement(A<By>._)).Returns(this.WebElement);
            this.FormHelper = new FormHelper(this.WebDriver, this.WebDriverWaitHelper);
        }

        public IWebElement WebElement { get; set; }

        public IWebDriver WebDriver { get; set; }

        public FormHelper FormHelper { get; set; }

        public IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        public RetrySettings RetrySettings { get; } = new RetrySettings()
        {
            ExplicitWaitInSeconds = 1,
            NumberOfRetries = 1,
        };

        [Fact]
        public void SelectRadioButtonWaitsForElementToBeClickable()
        {
            this.FormHelper.SelectRadioButton(this.WebElement);
            A.CallTo(() => this.WebDriverWaitHelper.WaitForElementToBeClickable(this.WebElement)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void SelectRadioButtonWithLocatorWaitsForElementToBeClickable()
        {
            this.FormHelper.SelectRadioButton(By.Id("id"));
            A.CallTo(() => this.WebDriverWaitHelper.WaitForElementToBeClickable(this.WebElement)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void EnterTextClearsEditableTextField()
        {
            this.FormHelper.EnterText(this.WebElement, "text value");
            A.CallTo(() => this.WebElement.Clear()).MustHaveHappenedOnceExactly();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void EnterTextWithEmptyTextValueThrowsArgumentException(string textValue)
        {
            Assert.Throws<ArgumentException>(() => this.FormHelper.EnterText(this.WebElement, textValue));
        }

        [Fact]
        public void EnterTextWithLocatorClearsEditableTextField()
        {
            this.FormHelper.EnterText(By.Id("id"), "text value");
            A.CallTo(() => this.WebElement.Clear()).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void EnterIntegerValueClearsEditableTextField()
        {
            this.FormHelper.EnterIntegerValue(this.WebElement, 1);
            A.CallTo(() => this.WebElement.Clear()).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void EnterIntegerWithLocatorValueClearsEditableTextField()
        {
            this.FormHelper.EnterIntegerValue(By.Id("id"), 1);
            A.CallTo(() => this.WebElement.Clear()).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void CheckCheckboxWaitsForElementToBeClickable()
        {
            A.CallTo(() => this.WebElement.Displayed).Returns(true);
            this.FormHelper.CheckCheckbox(this.WebElement);
            A.CallTo(() => this.WebDriverWaitHelper.WaitForElementToBeClickable(this.WebElement)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void CheckCheckboxWhenAlreadyCheckedDoesNotClickTheCheckbox()
        {
            A.CallTo(() => this.WebElement.Selected).Returns(true);
            this.FormHelper.CheckCheckbox(this.WebElement);
            A.CallTo(() => this.WebElement.Click()).MustNotHaveHappened();
        }

        [Fact]
        public void CheckCheckboxThrowsArgumentNullExceptionWhenWebElementIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.FormHelper.CheckCheckbox(null));
        }

        [Fact]
        public void SelectByAttributeThrowsArgumentNullExceptionWhenWebElementIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.FormHelper.SelectByAttribute(null, "attributeName", "attribute"));
        }

        [Fact]
        public void SelectByAttributeThrowsNotFoundExceptionWhenNoOptionIsFound()
        {
            var optionOne = A.Fake<IWebElement>();
            var optionTwo = A.Fake<IWebElement>();
            A.CallTo(() => optionOne.GetAttribute(A<string>._)).Returns("A different attribute value");
            A.CallTo(() => optionTwo.GetAttribute(A<string>._)).Returns("A different attribute value");
            A.CallTo(() => this.WebElement.TagName).Returns("select");
            A.CallTo(() => this.WebElement.FindElements(A<By>._)).Returns(new ReadOnlyCollection<IWebElement>(new List<IWebElement>() { optionOne, optionTwo }));
            var selectElement = A.Fake<SelectElement>((fake) => fake.WithArgumentsForConstructor(() => new SelectElement(this.WebElement)));

            Assert.Throws<NotFoundException>(() => this.FormHelper.SelectByAttribute(selectElement, "attributeName", "attribute"));
        }

        [Fact]
        public void SelectByAttributeThrowsNotsFoundExceptionWhenNoOptionIsFound()
        {
            var optionOne = A.Fake<IWebElement>();
            var optionTwo = A.Fake<IWebElement>();
            A.CallTo(() => optionOne.GetAttribute(A<string>._)).Returns("A different attribute value");
            A.CallTo(() => optionTwo.GetAttribute(A<string>._)).Returns("attribute");
            A.CallTo(() => this.WebElement.TagName).Returns("select");
            A.CallTo(() => this.WebElement.FindElements(A<By>._)).Returns(new ReadOnlyCollection<IWebElement>(new List<IWebElement>() { optionOne, optionTwo }));
            var selectElement = A.Fake<SelectElement>((fake) => fake.WithArgumentsForConstructor(() => new SelectElement(this.WebElement)));
            this.FormHelper.SelectByAttribute(selectElement, "attributeName", "attribute");

            A.CallTo(() => this.WebDriverWaitHelper.WaitForElementToBeClickable(optionTwo)).MustHaveHappenedOnceExactly();
        }
    }
}