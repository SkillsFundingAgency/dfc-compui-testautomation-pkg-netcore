// <copyright file="IBrowserHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DFC.TestAutomation.UI.Helper
{
    public interface IBrowserHelper
    {
        BrowserType GetBrowserType();

        bool IsExecutingInTheCloud();
    }
}
