// <copyright file="IAxeHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// An interface containing definitions for all axe (web accessibility testing) related operations.
    /// </summary>
    public interface IAxeHelper
    {
        /// <summary>
        /// Runs axe analysis on the current page. The axe results are stored in the AxeOutput folder in the base directory.
        /// </summary>
        void Analyse();
    }
}
