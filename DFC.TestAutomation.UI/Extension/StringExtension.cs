﻿// <copyright file="StringExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DFC.TestAutomation.UI.Extension
{
    public static class StringExtension
    {
        public static bool ContainsCompareCaseInsensitive(this string text, string value, StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            var index = text?.IndexOf(value, stringComparison);
            return index >= 0;
        }

        public static bool CompareToIgnoreCase(this string stringOne, string strB)
        {
            return string.Compare(stringOne.RemoveAllSpaces(), strB, true, CultureInfo.CurrentCulture) == 0;
        }

        public static string RemoveAllSpaces(this string s)
        {
            return Regex.Replace(s, @"\s+", string.Empty);
        }
    }
}
