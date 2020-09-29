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

    }
}
