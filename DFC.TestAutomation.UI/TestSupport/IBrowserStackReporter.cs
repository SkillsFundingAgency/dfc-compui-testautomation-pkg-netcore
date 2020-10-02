// <copyright file="IBrowserStackReporter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DFC.TestAutomation.UI.TestSupport
{
    public interface IBrowserStackReporter
    {
        void SendMessage(string status, string message);
    }
}
