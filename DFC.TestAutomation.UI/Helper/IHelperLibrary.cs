// <copyright file="IHelperLibrary.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// An interface containing all helper library definitions.
    /// </summary>
    public interface IHelperLibrary
    {
        /// <summary>
        /// Gets the axe (web accessibility) helper.
        /// </summary>
        IAxeHelper AxeHelper { get; }

        /// <summary>
        /// Gets the browser helper.
        /// </summary>
        IBrowserHelper BrowserHelper { get; }

        /// <summary>
        /// Gets the form helper.
        /// </summary>
        IFormHelper FormHelper { get; }

        /// <summary>
        /// Gets the javascript helper.
        /// </summary>
        IJavaScriptHelper JavaScriptHelper { get; }

        /// <summary>
        /// Gets the common action helper.
        /// </summary>
        ICommonActionHelper CommonActionHelper { get; }

        /// <summary>
        /// Gets the webdriver wait helper.
        /// </summary>
        IWebDriverWaitHelper WebDriverWaitHelper { get; }

        /// <summary>
        /// Gets the retry helper.
        /// </summary>
        IRetryHelper RetryHelper { get; }

        /// <summary>
        /// Gets the screenshot helper.
        /// </summary>
        IScreenshotHelper ScreenshotHelper { get; }
    }
}
