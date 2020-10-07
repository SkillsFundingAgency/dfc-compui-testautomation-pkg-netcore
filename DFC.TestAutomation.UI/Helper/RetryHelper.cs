// <copyright file="RetryHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// </copyright>

using Polly;
using System;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// Provides helper functions for operations that require exception handling and retry actions.
    /// </summary>
    public class RetryHelper : IRetryHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetryHelper"/> class.
        /// </summary>
        public RetryHelper()
        {
            this.SleepDurations = new TimeSpan[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3) };
        }

        private TimeSpan[] SleepDurations { get; set; }

        /// <summary>
        /// Attempts to execute an action. If the action throws an exception, then the execution pauses for a number of seconds.
        /// The retry action is then executed provided the retry count has not been exceeded. Once the retry action has completed,
        /// then the action is attempted once again. This pattern continues on a loop until the retry count is exceeded or the action
        /// does not throw an exception.
        /// </summary>
        /// <typeparam name="T">The return type for the action.</typeparam>
        /// <param name="action">The action to be taken.</param>
        /// <param name="retryAction">The retry action. This is carried out only when an exception is caught while executing the action, and when the retry count has not been exceeded.</param>
        /// <returns>The return value from the action.</returns>
        public T RetryOnException<T>(Func<T> action, Action<Exception, TimeSpan, int, Context> retryAction)
        {
            return Policy.Handle<Exception>().WaitAndRetry(this.SleepDurations, retryAction).Execute(action);
        }

        /// <summary>
        /// Attempts to execute an action. If the action throws an exception, then the execution pauses for a number of seconds.
        /// The the action is attempted once again. This pattern continues on a loop until the retry count is exceeded or the action
        /// does not throw an exception.
        /// </summary>
        /// <typeparam name="T">The return type for the action.</typeparam>
        /// <param name="action">The action to be taken.</param>
        /// <returns>The return value from the action.</returns>
        public T RetryOnException<T>(Func<T> action)
        {
            return Policy.Handle<Exception>().WaitAndRetry(this.SleepDurations).Execute(action);
        }

        /// <summary>
        /// Attempts to execute an action. If the action throws an exception, then the execution pauses for a number of seconds.
        /// The the action is attempted once again. This pattern continues on a loop until the retry count is exceeded or the action
        /// does not throw an exception.
        /// </summary>
        /// <param name="action">The action to be taken.</param>
        public void RetryOnException(Action action)
        {
            Policy.Handle<Exception>().WaitAndRetry(this.SleepDurations).Execute(action);
        }

        /// <summary>
        /// Attempts to execute an action. If the action throws an exception, then the execution pauses for a number of seconds.
        /// The retry action is then executed provided the retry count has not been exceeded. Once the retry action has completed,
        /// then the action is attempted once again. This pattern continues on a loop until the retry count is exceeded or the action
        /// does not throw an exception.
        /// </summary>
        /// <param name="action">The action to be taken.</param>
        /// <param name="retryAction">The retry action. This is carried out only when an exception is caught while executing the action, and when the retry count has not been exceeded.</param>
        public void RetryOnException(Action action, Action<Exception, TimeSpan, int, Context> retryAction)
        {
            Policy.Handle<Exception>().WaitAndRetry(this.SleepDurations, retryAction).Execute(action);
        }
    }
}