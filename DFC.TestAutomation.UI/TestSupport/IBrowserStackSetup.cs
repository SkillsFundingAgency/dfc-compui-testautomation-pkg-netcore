using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.TestSupport
{
    public interface IBrowserStackSetup
    {
        IWebDriver CreateRemoteWebDriver();
    }
}
