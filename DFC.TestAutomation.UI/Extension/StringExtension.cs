// <copyright file="StringExtension.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Text.RegularExpressions;

namespace DFC.TestAutomation.UI.Extension
{
    /// <summary>
    /// Provides useful functions when handling a string.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Removes all spaces.
        /// </summary>
        /// <param name="stringValue">The string.</param>
        /// <returns>The string value with all space characters removed.</returns>
        public static string RemoveAllSpaces(this string stringValue)
        {
            return Regex.Replace(stringValue, @"\s+", string.Empty);
        }
    }
}
