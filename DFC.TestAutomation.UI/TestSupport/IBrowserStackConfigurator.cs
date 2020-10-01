using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.TestSupport
{
    public interface IBrowserStackConfigurator
    {
        IWebDriver CreateRemoteWebDriver();
    }
}
