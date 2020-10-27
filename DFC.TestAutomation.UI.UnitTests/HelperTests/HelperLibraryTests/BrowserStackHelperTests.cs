// <copyright file="BrowserStackHelperTests.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using DFC.TestAutomation.UI.Helper;
using DFC.TestAutomation.UI.Settings;
using System.Configuration;
using Xunit;

namespace DFC.TestAutomation.UI.UnitTests.HelperTests.HelperLibraryTests
{
    public class BrowserStackHelperTests
    {
        public BrowserStackSettings BrowserStackSettings { get; } = new BrowserStackSettings()
        {
            BrowserName = "Chrome",
            AccessKey = "key",
            BrowserVersion = null,
            Build = "Build name",
            EnableDebug = false,
            EnableNetworkLogs = false,
            EnableSeleniumLogs = false,
            RecordVideo = false,
            Name = "Session name",
            OperatingSystem = "Windows",
            OperatingSystemVersion = "10",
            Project = "Project name",
            ScreenResolution = null,
            Username = "Username123",
        };

        [Fact]
        public void UnrecognisedBrowserName()
        {
            var browserStackSettings = this.BrowserStackSettings;
            browserStackSettings.BrowserName = "unrecognised-browser-name";
            Assert.Throws<ConfigurationErrorsException>(() => new BrowserStackHelper<IAppSettings>(browserStackSettings));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("username123", null)]
        [InlineData("username123", "")]
        [InlineData(null, "accesskey123")]
        [InlineData("", "accesskey123")]
        public void MissingUsernameAndOrAccessKey(string username, string accessKey)
        {
            var browserStackSettings = this.BrowserStackSettings;
            browserStackSettings.Username = username;
            browserStackSettings.AccessKey = accessKey;
            Assert.Throws<ConfigurationErrorsException>(() => new BrowserStackHelper<IAppSettings>(browserStackSettings));
        }
    }
}
