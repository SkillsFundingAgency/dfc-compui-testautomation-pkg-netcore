﻿using DFC.TestAutomation.UI.Config;
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
        private readonly FrameworkConfig _frameworkConfig;
        private readonly ObjectContext _objectContext;

        public BrowserStackTearDown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _frameworkConfig = _context.Get<FrameworkConfig>();
        }

        [AfterScenario(Order = 12)]
        public void InformBrowserStackOnFailure()
        {
            if (_context.TestError != null)
            {
                var browser = _objectContext.GetBrowser();
                var webDriver = _context.GetWebDriver();
                var errorMessage = _context.TestError.Message;

                switch (true)
                {
                    case bool _ when browser.IsCloudExecution():
                        try
                        {
                            RemoteWebDriver remoteWebDriver = (RemoteWebDriver)webDriver;
                            var sessionId = remoteWebDriver.SessionId.ToString();
                            BrowserStackReport.MarkTestAsFailed(_frameworkConfig.BrowserStackSetting, sessionId, errorMessage);
                        }
                        catch (Exception ex)
                        {
                            _objectContext.SetBrowserstackResponse();
                            _objectContext.SetAfterScenarioException(ex);
                        }
                        break;
                }
            }
        }
    }
}
