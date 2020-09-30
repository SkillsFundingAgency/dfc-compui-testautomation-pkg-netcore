﻿using OpenQA.Selenium;
using System.Linq;

namespace DFC.TestAutomation.UI.Helper
{
    public class TableRowHelper
    {
        private readonly IWebDriver _webDriver;
        private readonly FormCompletionHelper _formCompletionHelper;

        public TableRowHelper(IWebDriver webDriver, FormCompletionHelper formCompletionHelper)
        {
            _webDriver = webDriver;
            _formCompletionHelper = formCompletionHelper;
        }

        public void SelectRowFromTable(string byLinkText, string byKey)
        {
            var table = _webDriver.FindElement(By.TagName("table"));
            var tableRows = table.FindElements(By.CssSelector("tbody tr"));
            var links = _webDriver.FindElements(By.PartialLinkText(byLinkText));
            int i = 0;
            foreach (IWebElement tableRow in tableRows)
            {
                if (tableRow.Text.Contains(byKey))
                {
                    links[i].Click();
                    break;
                }
                i++;
            }
        }

        public void SelectRowForMultipleTables(string byLinkText, string byKey)
        {
            var tableRows = _webDriver.FindElements(By.TagName("tr"));
            var requiredRow = (from tr in tableRows
                               from td in tr.FindElements(By.TagName("td"))
                               where td.Text.Trim() == byKey
                               select tr)?.FirstOrDefault();

            var linkToClick = requiredRow.FindElement(By.LinkText(byLinkText));
            linkToClick.Click();
        }
    }
}
