using DFC.TestAutomation.UI.Config;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.Hooks.AfterScenario
{
    [Binding]
    public class BrowserStackTearDown
    {
        private readonly ScenarioContext _context;
        private readonly BrowserStackConfiguration _browserStackConfig;
        private readonly ObjectContext _objectContext;

        public BrowserStackTearDown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _browserStackConfig = _context.Get<BrowserStackConfiguration>();
        }
    }
}
