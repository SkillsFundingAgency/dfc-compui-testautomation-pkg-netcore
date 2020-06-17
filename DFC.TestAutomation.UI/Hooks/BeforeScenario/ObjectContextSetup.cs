using DFC.TestAutomation.UI.TestSupport;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.Hooks.BeforeScenario
{
    [Binding]
    public class ObjectContextSetup
    {
        private readonly ScenarioContext _context;

        public ObjectContextSetup(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario(Order = 0)]
        public void SetObjectContext(ObjectContext objectContext) => _context.Set(objectContext);
    }
}
