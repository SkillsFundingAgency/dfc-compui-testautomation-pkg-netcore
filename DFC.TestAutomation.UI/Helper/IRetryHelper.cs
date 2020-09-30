using Polly;
using System;

namespace DFC.TestAutomation.UI.Helper
{
    public interface IRetryHelper
    {
        Action<Exception, TimeSpan, int, Context> CreateRetryAction(Action func);

        T RetryOnException<T>(Func<T> action, Action<Exception, TimeSpan, int, Context> retryAction);

        T RetryOnException<T>(Func<T> action);

        void RetryOnException(Action action, Action<Exception, TimeSpan, int, Context> retryAction);

        void RetryOnException(Action action);
    }
}
