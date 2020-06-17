﻿using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.Hooks.AfterScenario
{
    [Binding]
    public class ScreenshotTeardown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public ScreenshotTeardown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [AfterScenario(Order = 11)]
        public void TakeScreenshotOnFailure()
        {
            if (_context.TestError != null)
            {
                try
                {
                    var scenarioTitle = _context.ScenarioInfo.Title;
                    var webDriver = _context.GetWebDriver();
                    var directory = _objectContext.GetDirectory();

                    _objectContext.SetUrl(webDriver.Url);

                    ScreenshotHelper.TakeScreenShot(webDriver, directory, scenarioTitle, true);
                }
                catch (Exception ex)
                {
                    _objectContext.SetAfterScenarioException(ex);
                }
            }
        }
    }
}
