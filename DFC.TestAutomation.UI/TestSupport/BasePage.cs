using DFC.TestAutomation.UI.Helper;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.TestSupport
{
    public abstract class BasePage
    {
        protected IHelperLibrary HelperLibrary { get; set; }

        protected virtual By PageHeader => By.ClassName("govuk-heading-xl");

        protected abstract string PageTitle { get; }

        public BasePage(ScenarioContext context)
        {
            this.HelperLibrary = context.Get<IHelperLibrary>();
        }

        public bool VerifyPage()
        {
            return this.HelperLibrary.PageInteractionHelper.VerifyPage(PageHeader, PageTitle);
        }
    }
}