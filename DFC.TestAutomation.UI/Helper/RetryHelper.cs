// <copyright file="RetryHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Polly;
using System;

namespace DFC.TestAutomation.UI.Helper
{
    public class RetryHelper : IRetryHelper
    {
        public RetryHelper()
        {
            this.SleepDurations = new TimeSpan[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3) };
        }

        private TimeSpan[] SleepDurations { get; set; }

        public Action<Exception, TimeSpan, int, Context> CreateRetryAction(Action func)
        {
            return (exception, timeSpan, retryCount, context) =>
            {
                func.Invoke();
            };
        }

        public T RetryOnException<T>(Func<T> action, Action<Exception, TimeSpan, int, Context> retryAction)
        {
            return Policy.Handle<Exception>().WaitAndRetry(this.SleepDurations, retryAction).Execute(action);
        }

        public T RetryOnException<T>(Func<T> action)
        {
            return Policy.Handle<Exception>().WaitAndRetry(this.SleepDurations).Execute(action);
        }

        public void RetryOnException(Action action)
        {
            Policy.Handle<Exception>().WaitAndRetry(this.SleepDurations).Execute(action);
        }

        public void RetryOnException(Action action, Action<Exception, TimeSpan, int, Context> retryAction)
        {
            Policy.Handle<Exception>().WaitAndRetry(this.SleepDurations, retryAction).Execute(action);
        }
    }
}