// <copyright file="CommonActionHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// Provides helper functions for all common operations.
    /// </summary>
    public class CommonActionHelper : ICommonActionHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonActionHelper"/> class.
        /// </summary>
        /// <param name="webDriver">The Selenium webdriver.</param>
        /// <param name="webDriverWaitHelper">The Selenium webdriver wait helper.</param>
        /// <param name="retryHelper">The retry helper.</param>
        public CommonActionHelper(IWebDriver webDriver, IWebDriverWaitHelper webDriverWaitHelper, IRetryHelper retryHelper)
        {
            this.WebDriver = webDriver;
            this.WebDriverWaitHelper = webDriverWaitHelper;
            this.RetryHelper = retryHelper;
        }

        private IWebDriver WebDriver { get; set; }

        private IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        private IRetryHelper RetryHelper { get; set; }

        /// <summary>
        /// Assesses whether the IWebElement contains expected text. The comparison is case insensitive and the expected text parameter
        /// is trimmed before being compared.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <param name="expectedText">The expected text.</param>
        /// <returns>True if the IWebElement contains the expected text. False if the IWebElement does not contain the expected text.</returns>
        public bool ElementContainsText(By locator, string expectedText)
        {
            if (string.IsNullOrEmpty(expectedText))
            {
                throw new InvalidOperationException("Unable to assertain whether the web element contains null or an empty string. The expected text parameter must be provided.");
            }

            bool Action()
            {
                this.WebDriverWaitHelper.WaitForPageToLoad();
                var actual = this.GetText(locator);
                return actual.Contains(expectedText.Trim(), StringComparison.CurrentCultureIgnoreCase);
            }

            return this.RetryHelper.RetryOnException(Action);
        }

        /// <summary>
        /// Gets the attribute value for an IWebElement.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The atrribute value.</returns>
        public string GetAttributeValue(By locator, string attributeName)
        {
            string Action()
            {
                return this.WebDriver.FindElement(locator).GetAttribute(attributeName);
            }

            return this.RetryHelper.RetryOnException(Action);
        }

        /// <summary>
        /// Gets the text value from all IWebElements with a given locator.
        /// </summary>
        /// <param name="locator">The IWebELement locator.</param>
        /// <returns>The string value.</returns>
        public string GetTextFromElements(By locator)
        {
            var text = string.Empty;
            IList<IWebElement> webElementGroup = this.WebDriver.FindElements(locator);

            foreach (IWebElement webElement in webElementGroup)
            {
                if (string.IsNullOrEmpty(text))
                {
                    text = this.GetText(webElement);
                }
                else
                {
                    text += $" {this.GetText(webElement)}";
                }
            }

            return text;
        }

        /// <summary>
        /// Gets the count of the IWebElement collection returned when locating all IWebElements with the given locator.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <returns>An integer indicating how many IWebElements are located using the locator.</returns>
        public int GetCountOfElements(By locator)
        {
            return this.WebDriver.FindElements(locator).Count;
        }

        /// <summary>
        /// Assesses whether an IWebElement is present.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <returns>A value indicating whether the IwebElement is present.</returns>
        public bool IsElementPresent(By locator)
        {
            this.WebDriverWaitHelper.SetImplicitWait(500);
            if (this.GetCountOfElements(locator) > 0)
            {
                this.WebDriverWaitHelper.ResetImplicitWait();
                return true;
            }

            this.WebDriverWaitHelper.ResetImplicitWait();
            return false;
        }

        /// <summary>
        /// Assesses whether an IWebElement is displayed.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <returns>A value indicating whether an IWebElement is displayed.</returns>
        public bool IsElementDisplayed(By locator)
        {
            this.WebDriverWaitHelper.SetImplicitWait(500);
            try
            {
                return this.WebDriver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            finally
            {
                this.WebDriverWaitHelper.ResetImplicitWait();
            }
        }

        /// <summary>
        /// Sets the focus on an IwebElement.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        public void SetElementFocus(By locator)
        {
            if (!this.IsElementPresent(locator))
            {
                throw new NotFoundException($"Unable to set the focus on the element with locator '{locator}' as the element cannot be found.");
            }

            IWebElement webElement = this.WebDriver.FindElement(locator);
            new Actions(this.WebDriver).MoveToElement(webElement).Perform();
            this.WebDriverWaitHelper.WaitForElementToBeDisplayed(locator);
        }

        /// <summary>
        /// Switches to an iframe.
        /// </summary>
        /// <param name="locator">The iframe locator.</param>
        public void SwitchToFrame(By locator)
        {
            this.WebDriverWaitHelper.WaitForFrameToBeAvailableAndSwitchToIt(locator);
        }

        /// <summary>
        /// Gets the text value from an IWebElement.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <returns>The text value from the IwebElement.</returns>
        public string GetText(By locator) => this.GetText(this.WebDriver.FindElement(locator));

        /// <summary>
        /// Gets the text value from an IWebElement.
        /// </summary>
        /// <param name="webElement">The IWebElement.</param>
        /// <returns>The text value from the IwebElement.</returns>
        public string GetText(IWebElement webElement) => webElement?.Text;

        /// <summary>
        /// Gets the current browsers url.
        /// </summary>
        /// <returns>The current url.</returns>
        public Uri GetUrl() => new Uri(this.WebDriver.Url);

        /// <summary>
        /// Gets all select options for a select IWebElement.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <returns>All select options.</returns>
        public IList<IWebElement> GetAllSelectOptions(By locator)
        {
            if (this.IsElementPresent(locator))
            {
                var webElement = this.WebDriver.FindElement(locator);

                if (webElement.TagName.Equals("select", StringComparison.CurrentCultureIgnoreCase))
                {
                    var selectElement = new SelectElement(webElement);
                    return selectElement.Options;
                }
                else
                {
                    throw new UnexpectedTagNameException("Unable to cast the web element as a SelectElement. Check that the locator provided is unique or that the intended element is the first web element on the page to match the locator.");
                }
            }
            else
            {
                throw new NotFoundException($"Unable to get the select options from the element with locator '{locator}' as the element cannot be found.");
            }
        }
    }
}