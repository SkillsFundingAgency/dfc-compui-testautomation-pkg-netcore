// <copyright file="IRetryHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Polly;
using System;

namespace DFC.TestAutomation.UI.Helper
{
    public interface IRetryHelper
    {
        T RetryOnException<T>(Func<T> action, Action<Exception, TimeSpan, int, Context> retryAction);

        T RetryOnException<T>(Func<T> action);

        void RetryOnException(Action action, Action<Exception, TimeSpan, int, Context> retryAction);

        void RetryOnException(Action action);
    }
}
