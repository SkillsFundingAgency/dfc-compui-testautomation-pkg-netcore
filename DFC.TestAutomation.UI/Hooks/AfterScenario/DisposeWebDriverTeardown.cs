using DFC.TestAutomation.UI.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.Hooks.AfterScenario
{
    [Binding]
    public class DisposeWebDriverTeardown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public DisposeWebDriverTeardown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [AfterScenario(Order = 13)]
        public void DisposeWebDriver()
        {
            try
            {
                var WebDriver = _context.GetWebDriver();

                if (DoNotDisposeWebDriver() == false)
                {
                    WebDriver?.Quit();
                    WebDriver?.Dispose();
                }
            }
            catch (Exception ex)
            {
                _objectContext.SetAfterScenarioException(ex);
            }
        }

        private bool DoNotDisposeWebDriver()
        {
            //Browserstack will leave the tests as inconclusive if they are timed out 
            //we wanted to leave the tests as inconclusive if for any reason Rest Api failed to update the results)
            return _context.TestError != null && _objectContext.GetBrowser().IsCloudExecution() && _objectContext.FailedtoUpdateTestResultInBrowserStack();
        }
    }
}
