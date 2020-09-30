﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DFC.TestAutomation.UI.Helper
{
    public class PageInteractionHelper : IPageInteractionHelper
    {
        private IWebDriver WebDriver { get; set; }

        private IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        private RetryHelper RetryHelper { get; set; }

        public PageInteractionHelper(IWebDriver webDriver, WebDriverWaitHelper webDriverWaitHelper, RetryHelper retryHelper)
        {
            this.WebDriver = webDriver;
            this.WebDriverWaitHelper = webDriverWaitHelper;
            this.RetryHelper = retryHelper;
        }

        public bool VerifyPage(By locator, string expected)
        {
            bool action()
            {
                this.WebDriverWaitHelper.WaitForPageToLoad();
                var actual = GetText(locator);
                return actual.Contains(expected);
            }

            return this.RetryHelper.RetryOnException(action);
        }

        public string GetAttributeValue(By locator, string attributeKey)
        {
            string action()
            { 
                return this.WebDriver.FindElement(locator).GetAttribute(attributeKey) as string; 
            };

            return this.RetryHelper.RetryOnException<string>(action);
        }

        public string GetTextFromElements(By locator)
        {
            var text = string.Empty;
            IList<IWebElement> webElementGroup = this.WebDriver.FindElements(locator);

            foreach (IWebElement webElement in webElementGroup)
                text += GetText(webElement);

            return text;
        }

        public int GetCountOfElements(By locator)
        {
            return this.WebDriver.FindElements(locator).Count;
        }

        public bool IsElementPresent(By locator)
        {
            this.WebDriverWaitHelper.SetImplicitWait(500);
            if(GetCountOfElements(locator) > 0)
            {
                this.WebDriverWaitHelper.ResetImplicitWait();
                return true;
            }

            this.WebDriverWaitHelper.ResetImplicitWait();
            return false;
        }

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

        public void SetElementFocus(By locator)
        {
            if(!IsElementPresent(locator))
            {
                throw new NotFoundException($"Unable to set the focus on the element with locator '{ locator }' as the element cannot be found.");
            }

            IWebElement webElement = this.WebDriver.FindElement(locator);
            new Actions(this.WebDriver).MoveToElement(webElement).Perform();
            this.WebDriverWaitHelper.WaitForElementToBeDisplayed(locator);
        }

        public void SwitchToFrame(By locator)
        {
            this.WebDriverWaitHelper.WebDriverImplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(locator));
        }

        public string GetText(By locator) => GetText(this.WebDriver.FindElement(locator));

        public string GetText(IWebElement webElement) => webElement.Text;

        public string GetUrl() => this.WebDriver.Url;

        public IWebElement GetLinkByText(By locator, string linkText) => GetLink(locator, (x) => x == linkText);

        public IWebElement GetLinkContainingText(By locator, string linkText) => GetLink(locator, (x) => x.ContainsCompareCaseInsensitive(linkText));

        public string GetTableRowContainingCellWithText(By tableIdentifier, string cellText)
        {
            return GetAllTableRows(tableIdentifier).Where(x => x.FindElements(By.CssSelector("td")).Any(y => y?.Text == cellText)).SingleOrDefault()?.Text;
        }

        public List<IWebElement> GetAllTableRows(By tableIdentifier)
        {
            return WebDriver.FindElement(tableIdentifier).FindElements(By.CssSelector("tr")).ToList();
        }

        private IWebElement GetLink(By locator, Func<string, bool> func) => this.WebDriver.FindElements(locator).ToList().First(x => func(x.GetAttribute("innerText")));

        public List<string> GetAllSelectOptions(By locator)
        {
            return new SelectElement(WebDriver.FindElement(locator)).Options.Where(t => string.IsNullOrEmpty(t.Text)).Select(x => x.Text).ToList();
        }

        public void WaitForElementToContainText(By locator, string text)
        {
            this.WebDriverWaitHelper.WaitForElementToContainText(locator, text);
        }
    }
}