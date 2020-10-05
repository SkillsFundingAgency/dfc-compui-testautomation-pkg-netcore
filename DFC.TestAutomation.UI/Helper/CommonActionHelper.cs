// <copyright file="PageInteractionHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

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

            return this.RetryHelper.RetryOnException<string>(Action);
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
                text += this.GetText(webElement);
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
            catch (Exception)
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
        /// Gets a hyperlink IWebElement with a specific text value.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <param name="linkText">The hyperlink text.</param>
        /// <returns>The hyperlink IWebElement with a text value equal to the link text.</returns>
        public IWebElement GetLinkByText(By locator, string linkText) => this.GetLink(locator, (x) => x == linkText);

        /// <summary>
        /// Gets a hyperlink IWebElement containing a specific text value.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <param name="linkText">The hyperlink text.</param>
        /// <returns>The hyperlink IWebElement with a text value containing the link text.</returns>
        public IWebElement GetLinkContainingText(By locator, string linkText) => this.GetLink(locator, (x) => x.Contains(linkText, StringComparison.CurrentCultureIgnoreCase));

        /// <summary>
        /// Gets a table row IWebElement containing a cell with specific text.
        /// </summary>
        /// <param name="tableIdentifier">The table IWebElement locator.</param>
        /// <param name="cellText">The cell text.</param>
        /// <returns>The table row IWebElement.</returns>
        public string GetTableRowContainingCellWithText(By tableIdentifier, string cellText)
        {
            return this.GetAllTableRows(tableIdentifier).Where(x => x.FindElements(By.CssSelector("td")).Any(y => y?.Text == cellText)).SingleOrDefault()?.Text;
        }

        /// <summary>
        /// Gets all table row IWebElements.
        /// </summary>
        /// <param name="tableIdentifier">The table IWebelement locator.</param>
        /// <returns>All table row IWebElements.</returns>
        public List<IWebElement> GetAllTableRows(By tableIdentifier)
        {
            return this.WebDriver.FindElement(tableIdentifier).FindElements(By.CssSelector("tr")).ToList();
        }

        /// <summary>
        /// Gets all select options for a select IWebElement.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <returns>All select options.</returns>
        public List<string> GetAllSelectOptions(By locator)
        {
            return new SelectElement(this.WebDriver.FindElement(locator)).Options.Where(t => string.IsNullOrEmpty(t.Text)).Select(x => x.Text).ToList();
        }

        private IWebElement GetLink(By locator, Func<string, bool> func) => this.WebDriver.FindElements(locator).ToList().First(x => func(x.GetAttribute("innerText")));
    }
}