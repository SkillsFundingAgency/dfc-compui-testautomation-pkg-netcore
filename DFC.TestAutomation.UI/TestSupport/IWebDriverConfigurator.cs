using DFC.TestAutomation.UI.Config;
using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.TestSupport
{
    public interface IWebDriverConfigurator
    {
        IWebDriver Create();
    }
}
