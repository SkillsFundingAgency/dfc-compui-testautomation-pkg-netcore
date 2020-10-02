// <copyright file="BasePage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using DFC.TestAutomation.UI.Helper;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.TestSupport
{
    public abstract class BasePage : IBasePage
    {
        public BasePage(ScenarioContext context)
        {
            this.HelperLibrary = context?.Get<IHelperLibrary>();
        }

        protected IHelperLibrary HelperLibrary { get; set; }

        protected virtual By PageHeader => By.ClassName("govuk-heading-xl");

        protected abstract string PageTitle { get; }

        public bool VerifyPage()
        {
            return this.HelperLibrary.CommonActionHelper.VerifyPage(this.PageHeader, this.PageTitle);
        }
    }
}