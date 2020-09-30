using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.Helper
{
    public interface IFormCompletionHelper
    {
        void SelectRadioButton(IWebElement element);

        void SelectRadioButton(By locator);

        void EnterText(IWebElement element, string text);

        void EnterText(By locator, string text);

        void EnterIntegerValue(IWebElement element, int value);

        void EnterIntegerValue(By locator, int value);

        void SelectByIndex(By locator, int index);

        void SelectByIndex(IWebElement element, int index);

        void SelectFromDropDownByValue(By locator, string value);

        void SelectFromDropDownByText(By locator, string text);

        void SelectFromDropDownByValue(IWebElement element, string value);

        void SelectFromDropDownByText(IWebElement element, string text);

        void CheckCheckbox(IWebElement element);

        void SelectFromDropDownByAttribute(By locator, string attributeKey, string attribute);
    }
}
