﻿// <copyright file="ScenarioContextExtension.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using DFC.TestAutomation.UI.Helper;
using DFC.TestAutomation.UI.Settings;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.Extension
{
    /// <summary>
    /// Provides useful functions for getting and setting commonly used objects.
    /// </summary>
    public static class ScenarioContextExtension
    {
        /// <summary>
        /// Gets the object context.
        /// </summary>
        /// <param name="context">Scenario context.</param>
        /// <returns>A stored instance of the object context.</returns>
        public static IObjectContext GetObjectContext(this ScenarioContext context)
        {
            return context?.Get<ObjectContext>();
        }

        /// <summary>
        /// Sets the object context.
        /// </summary>
        /// <param name="context">Scenario context.</param>
        /// <param name="objectContext">Object context.</param>
        public static void SetObjectContext(this ScenarioContext context, IObjectContext objectContext)
        {
            context?.Set(objectContext);
        }

        /// <summary>
        /// Gets the Selenium Webdriver.
        /// </summary>
        /// <param name="context">Scenario context.</param>
        /// <returns>A stored instance of the Selenium Webdriver.</returns>
        public static IWebDriver GetWebDriver(this ScenarioContext context)
        {
            return context?.Get<IWebDriver>();
        }

        /// <summary>
        /// Sets the Selenium Webdriver.
        /// </summary>
        /// <param name="context">Scenario context.</param>
        /// <param name="webDriver">Selenium Webdriver.</param>
        public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver)
        {
            context?.Set(webDriver);
        }

        /// <summary>
        /// Gets the settings library.
        /// </summary>
        /// <typeparam name="T">The application settings type. This must be an interface member of IAppSettings.</typeparam>
        /// <param name="context">Scenario context.</param>
        /// <returns>A stored instance of the settings library.</returns>
        public static ISettingsLibrary<T> GetSettingsLibrary<T>(this ScenarioContext context)
            where T : IAppSettings
        {
            return context?.Get<ISettingsLibrary<T>>();
        }

        /// <summary>
        /// Sets the settings library.
        /// </summary>
        /// <typeparam name="T">The application settings type. This must be an interface member of IAppSettings.</typeparam>
        /// <param name="context">Scenario context.</param>
        /// <param name="settingsLibrary">Settings library.</param>
        public static void SetSettingsLibrary<T>(this ScenarioContext context, ISettingsLibrary<T> settingsLibrary)
            where T : IAppSettings
        {
            context?.Set(settingsLibrary);
        }

        /// <summary>
        /// Gets the helper library.
        /// </summary>
        /// <param name="context">Scenario context.</param>
        /// <returns>A stored instance of the helper library.</returns>
        public static IHelperLibrary<T> GetHelperLibrary<T>(this ScenarioContext context)
            where T : IAppSettings
        {
            return context?.Get<IHelperLibrary<T>>();
        }

        /// <summary>
        /// Sets the helper library.
        /// </summary>
        /// <param name="context">Scenario context.</param>
        /// <param name="helperLibrary">Helper library.</param>
        public static void SetHelperLibrary<T>(this ScenarioContext context, IHelperLibrary<T> helperLibrary)
            where T : IAppSettings
        {
            context?.Set(helperLibrary);
        }
    }
}
