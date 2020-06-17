using DFC.TestAutomation.UI.Helpers;

namespace DFC.TestAutomation.UI.Config
{
    public class FrameworkConfig
    {
        public TimeOutConfig TimeOutConfig { get; set; }

        public BrowserStackSetting BrowserStackSetting { get; set; }

        public bool TakeEveryPageScreenShot { get; set; }
    }
}
