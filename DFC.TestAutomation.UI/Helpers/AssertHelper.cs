using NUnit.Framework;
using Polly;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.TestAutomation.UI.Helpers
{
    public class AssertHelper
    {
        public void RetryOnNUnitException(Action action)
        {
            Policy
                 .Handle<AssertionException>()
                 .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                 {
                     TestContext.Progress.WriteLine($"Retry Count : {retryCount}, Exception : {exception.Message}");
                 })
                 .Execute(() =>
                 {
                     using (var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext())
                     {
                         action.Invoke();
                     }
                 });
        }

        private static TimeSpan[] TimeOut => new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2)
        };
    }
}
