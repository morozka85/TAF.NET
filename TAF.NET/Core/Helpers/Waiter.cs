using Serilog;
using System.Diagnostics;
using TAF.Core.Configuration;

namespace TAF.Core.Helpers
{
    public static class Waiter
    {
        private const int MillisecondsDelay = 1000;

        public static void WaitFor(Func<bool> condition, int? millisecondsToWait = null)
        {
            var testSettings = ConfigurationHelper.GetApplicationConfiguration<TestSettings>();
            
            if (testSettings == null)
            {
                throw new InvalidOperationException("Test settings are not configured properly.");
            }
            
            var millisecondsTimeout = millisecondsToWait ?? testSettings.TimeoutDefault;

            Stopwatch stopwatch = Stopwatch.StartNew();

            while (stopwatch.ElapsedMilliseconds < millisecondsTimeout)
            {
                try
                {
                    if (condition.Invoke())
                    {
                        return;
                    }

                    Task.Delay(MillisecondsDelay).Wait();
                }
                catch (Exception e)
                {
                    Log.Logger.Warning(e.Message, "Error while waiting for condition.");
                    Task.Delay(MillisecondsDelay).Wait();
                }
            }

            stopwatch.Stop();
            Log.Logger.Warning("Timeout occurred after waiting for default milliseconds:", millisecondsTimeout);
            throw new TimeoutException($"Condition was not met within the timeout of {millisecondsTimeout} milliseconds.");
        }
    }
}
