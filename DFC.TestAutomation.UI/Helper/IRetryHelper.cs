// <copyright file="IRetryHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Polly;
using System;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// An interface containing definitions for all operations that assist 'retry on error'.
    /// </summary>
    public interface IRetryHelper
    {
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
        T RetryOnException<T>(Func<T> action, Action<Exception, TimeSpan, int, Context> retryAction);

        /// <summary>
        /// Attempts to execute an action. If the action throws an exception, then the execution pauses for a number of seconds.
        /// The the action is attempted once again. This pattern continues on a loop until the retry count is exceeded or the action
        /// does not throw an exception.
        /// </summary>
        /// <typeparam name="T">The return type for the action.</typeparam>
        /// <param name="action">The action to be taken.</param>
        /// <returns>The return value from the action.</returns>
        T RetryOnException<T>(Func<T> action);

        /// <summary>
        /// Attempts to execute an action. If the action throws an exception, then the execution pauses for a number of seconds.
        /// The the action is attempted once again. This pattern continues on a loop until the retry count is exceeded or the action
        /// does not throw an exception.
        /// </summary>
        /// <param name="action">The action to be taken.</param>
        void RetryOnException(Action action);

        /// <summary>
        /// Attempts to execute an action. If the action throws an exception, then the execution pauses for a number of seconds.
        /// The retry action is then executed provided the retry count has not been exceeded. Once the retry action has completed,
        /// then the action is attempted once again. This pattern continues on a loop until the retry count is exceeded or the action
        /// does not throw an exception.
        /// </summary>
        /// <param name="action">The action to be taken.</param>
        /// <param name="retryAction">The retry action. This is carried out only when an exception is caught while executing the action, and when the retry count has not been exceeded.</param>
        void RetryOnException(Action action, Action<Exception, TimeSpan, int, Context> retryAction);
    }
}
