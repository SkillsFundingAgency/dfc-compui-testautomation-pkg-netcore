using OpenQA.Selenium;
using System.Collections.Generic;

namespace DFC.TestAutomation.UI.Helpers
{
    public interface IPageInteractionHelper
    {
        bool VerifyPage(By locator, string expected);

        string GetAttributeValue(By locator, string attributeKey);

        string GetTextFromElements(By locator);

        int GetCountOfElements(By locator);

        bool IsElementPresent(By locator);

        bool IsElementDisplayed(By locator);

        void SetElementFocus(By locator);

        void SwitchToFrame(By locator);

        string GetText(By locator);

        string GetText(IWebElement webElement);

        string GetUrl();

        IWebElement GetLinkByText(By locator, string linkText);

        IWebElement GetLinkContainingText(By locator, string linkText);

        string GetTableRowContainingCellWithText(By tableIdentifier, string cellText);

        List<IWebElement> GetAllTableRows(By tableIdentifier);

        List<string> GetAllSelectOptions(By locator);

        void WaitForElementToContainText(By locator, string text);
    }
}
