using DFC.TestAutomation.UI.Config;
using DFC.TestAutomation.UI.Extension;
using DFC.TestAutomation.UI.Helper;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.TestSupport
{
    public abstract class BasePage<T> where T : IConfiguration
    {
        private IPageInteractionHelper PageInteractionHelper { get; set; }

        protected IConfigurator<T> Configuration { get; set; }

        private IWebDriver WebDriver { get; set; }

        private BrowserHelper BrowserHelper { get; set; }

        protected virtual By PageHeader => By.ClassName("govuk-heading-xl");

        protected abstract string PageTitle { get; }

        public BasePage(ScenarioContext context)
        {
            this.Configuration = context.GetConfiguration<T>();
            this.WebDriver = context.GetWebDriver();
            this.PageInteractionHelper = context.Get<PageInteractionHelper>();
            this.BrowserHelper = new BrowserHelper(context.GetConfiguration<T>().Data.BrowserConfiguration.BrowserName);
        }

        public bool VerifyPage()
        {
            return PageInteractionHelper.VerifyPage(PageHeader, PageTitle);
        }
    }
}