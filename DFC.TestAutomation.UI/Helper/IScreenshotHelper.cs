// <copyright file="IScreenshotHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// </copyright>

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// An interface containing definitions for all screenshot related operations.
    /// </summary>
    public interface IScreenshotHelper
    {
        /// <summary>
        /// Takes a screenshot of the current web browser view. The resulting screenshots can be found in the 'screenshots' folder
        /// within the base directory. The subfolder will be time stamped.
        /// </summary>
        void TakeScreenshot();
    }
}
