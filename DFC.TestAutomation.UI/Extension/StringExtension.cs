// <copyright file="StringExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
