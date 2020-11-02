// <copyright file="IActionsFactory.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OpenQA.Selenium.Interactions;

namespace DFC.TestAutomation.UI.Factory
{
    /// <summary>
    /// An interface containing definitions for all Actions related operations.
    /// </summary>
    public interface IActionsFactory
    {
        /// <summary>
        /// Creates a new instance of the Actions class.
        /// </summary>
        /// <returns>The Actions class.</returns>
        Actions Create();
    }
}
