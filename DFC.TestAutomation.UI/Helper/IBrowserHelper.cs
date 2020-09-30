namespace DFC.TestAutomation.UI.Helper
{
    public interface IBrowserHelper
    {
        BrowserType GetBrowserType();

        bool IsExecutingInTheCloud();
    }
}
