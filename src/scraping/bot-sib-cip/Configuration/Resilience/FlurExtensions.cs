namespace CipScrapingBot.Resilience
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using Polly;
    using Polly.Contrib.WaitAndRetry;
    using Polly.Retry;
    using Serilog;

    public class FlurExtensions
    {
        private static AsyncRetryPolicy<HttpResponseMessage> RetryPolicy
        {
            get
            {
                var maxDelay = TimeSpan.FromMinutes(3);
                var delay = Backoff
                    .DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(5), 5)
                    .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks)));

                return Policy
                    .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                    .WaitAndRetryAsync(delay,
                        (delegateResult, timeSpan, retryCount, context) =>
                        {
                            Log.Warning($"Share data failed with status {delegateResult.Result?.StatusCode}." +
                                        $"Waiting {timeSpan} before next retry. Retry attempt {retryCount}.");
                        });
            }
        }

        public static AsyncPolicy<HttpResponseMessage> PolicyStrategy => RetryPolicy;
    }
}