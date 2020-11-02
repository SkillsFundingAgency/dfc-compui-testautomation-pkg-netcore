// <copyright file="ActionsFactory.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DFC.TestAutomation.UI.Factory
{
    public class ActionsFactory : IActionsFactory
    {
        public ActionsFactory(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
        }

        private IWebDriver WebDriver { get; set; }

        /// <summary>
        /// Creates a new instance of the Actions class.
        /// </summary>
        /// <returns>The Actions class.</returns>
        public Actions Create()
        {
            return new Actions(this.WebDriver);
        }
    }
}
